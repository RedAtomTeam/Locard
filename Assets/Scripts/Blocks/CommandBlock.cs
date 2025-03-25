using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;


public class CommandBlock : Block, IMovable
{
    private Tween _currentTween;


    public void MoveTo(Vector3Int vector)
    {
        float moveTime = vector.magnitude * 0.1f;

        if (this._currentTween != null && this._currentTween.IsActive())
        {
            this._currentTween.Complete();
        }

        Vector3Int oldPos = this.Pos;
        Vector3Int targetPos = this.Pos + vector;

        Collider[] colliders = Physics.OverlapSphere(this.Pos + vector, 0.2f);
        if (colliders.Length > 0)
        {
            return;
        }

        List<Block> blocks;
        List<Block> blocksToPush = new List<Block>();

        bool canMove = true;

        if (this.LevelGrid.CheckBlockAt(this.Pos + vector, out blocks))
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                if (blocks[i].Collidable == CollideStatus.Tangible)
                {
                    if (blocks[i] is IMovable movableBlock)
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
                    else
                    {
                        canMove = false;
                    }
                }
            }
        }
        if (canMove)
        {
            for (int i = 0; i < blocksToPush.Count; i++)
            {
                ((IMovable)blocksToPush[i]).MoveTo(vector);
            }

            this.Pos = targetPos;
            this.LevelGrid.UpdateBlock(this, oldPos);

            this._currentTween = this.gameObject.transform.DOMove(targetPos, moveTime, false).OnComplete(
                () =>
                {
                    //Vector3Int oldPos = this.Pos;
                    //this.Pos = targetPos;
                    //this.LevelGrid.UpdateBlock(this, oldPos);
                }
            );
        }
    }


    public bool CanPushTo(Vector3Int vector)
    {
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
                if (blocks[i].Collidable == CollideStatus.Tangible)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public virtual bool Equals(CommandBlock other)
    {
        if (other == null || GetType() != other.GetType())
        {
            return false;
        }
        return true;
    }
}


