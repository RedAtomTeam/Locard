

public interface ICollidable
{
    public CollideStatus Collidable { get; set; }


}


public enum CollideStatus
{
    Tangible,
    Viscous,
    Intangible
}