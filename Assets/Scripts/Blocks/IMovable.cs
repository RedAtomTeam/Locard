using UnityEngine;

public interface IMovable 
{
    public void MoveTo(Vector3Int vector)
    {
        
    }

    public bool CanPushTo(Vector3Int pos)
    {
        return false;
    }
}

