using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class Entity : Block, IControllable
{
    public bool IsDamaging;
    public bool defaultDamaging;

    public bool IsHot;
    public bool defaultHot;

    public bool IsToxic;
    public bool defaultToxic;

    public bool IsFixed;
    public bool defaultFixed;

    private Tween _currentTween;    // Храним текущую анимацию, чтобы отменять или дожидаться её

    public override void SetDefaultState()
    {
        this.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = this.defaultColor;
        this.Collidable = this.defaultCollidable;
        this.IsDamaging = this.defaultDamaging;
        this.IsHot = this.defaultHot;
        this.IsToxic = this.defaultToxic;
        this.IsFixed = this.defaultFixed;
    }


    // Обработка ввода
    public void HandleInput(Vector3Int dir, LevelController levelController)
    {
        DOTween.CompleteAll();
        MoveTo(dir, levelController);
    }

    // Движение
    public bool MoveTo(Vector3Int vector, LevelController levelController = null)
    {
        if (this.IsFixed)
        {
            return false;
        }

        float moveTime = vector.magnitude * 0.1f;

        if (this._currentTween != null && this._currentTween.IsActive())
        {
            this._currentTween.Complete();
        }

        Vector3Int oldPos = this.Pos;
        Vector3Int targetPos = this.Pos + vector;

        Collider[] colliders = Physics.OverlapSphere(targetPos, 0.2f);
        if (colliders.Length > 0)
        {
            return false;
        }

        List<Block> blocks;
        List<Block> blocksToPush = new List<Block>();

        bool canMove = true;

        if (this.Collidable == CollideStatus.Tangible)
        {
            if (this.LevelGrid.CheckBlockAt(targetPos, out blocks))
            {
                for (int i = 0; i < blocks.Count; i++)
                {
                    if (blocks[i].Collidable == CollideStatus.Tangible)
                    {
                        if (!((IMovable)blocks[i]).CanPushTo(vector))
                        {
                            canMove = false;
                        }
                        else
                        {
                            blocksToPush.Add(blocks[i]);
                        }
                    }
                }
            }
        }

        if (canMove)
        {
            for (int i = 0; i < blocksToPush.Count; i++)
            {
                if (blocksToPush[i] is Entity block2)
                {
                    block2.MoveTo(vector);

                }
                else
                {
                    ((IMovable)blocksToPush[i]).MoveTo(vector);

                }
            }

            this.Pos = targetPos;
            this.LevelGrid.UpdateBlock(this, oldPos);

            this._currentTween = this.gameObject.transform.DOMove(targetPos, moveTime, false).OnComplete(
                () =>
                {
                    //Vector3Int oldPos = this.Pos;
                    //this.Pos = targetPos;
                    //this.LevelGrid.UpdateBlock(this, oldPos);
                    if (levelController != null)
                    {
                        levelController.EndTurn();
                    }
                }
            );

        }
        return true;
    }


    public bool CanPushTo(Vector3Int vector)
    {
        if (this.IsFixed)
        {
            return false;
        }

        Collider[] colliders = Physics.OverlapSphere(this.Pos + vector, 0.2f);
        if (colliders.Length > 0)
        {
            return false;
        }

        List<Block> blocks;
        if (this.LevelGrid.CheckBlockAt(this.Pos + vector, out blocks))
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                if (this.Collidable == CollideStatus.Tangible && blocks[i].Collidable == CollideStatus.Tangible)
                {
                    return false;
                }
                if (this.Collidable == CollideStatus.Viscous && blocks[i].Collidable == CollideStatus.Tangible)
                {
                    return false;
                }
            }
        }
        return true;
    }
}
