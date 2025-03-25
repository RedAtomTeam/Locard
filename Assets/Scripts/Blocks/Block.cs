using UnityEngine;
using Color = UnityEngine.Color;

public class Block : MonoBehaviour, IBlock, ICollidable
{
    public LevelGrid LevelGrid { get ; set; }
    public PhysicProcessor PhysicProcessor { get ; set; }
    public Vector3Int Pos { get; set; }
    public CollideStatus Collidable { get; set; }
    public CollideStatus defaultCollidable;
    public Color defaultColor;


    public void ChangeColor(Color color)
    {
        this.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = color;
    }

    public virtual void SetDefaultState()
    {
        gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = this.defaultColor;
        this.Collidable = this.defaultCollidable;
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}