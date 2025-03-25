using System.Collections.Generic;
using UnityEngine;

public class PhysicProcessor
{
    public Vector3Int _gravityVector;
    private const int MAXDEEP = 50;


    public PhysicProcessor (Vector3Int vector)
    {
        this._gravityVector = vector;
    }


    public Vector3Int FindFallFinalPosition(IMovable block, Vector3Int startPos)
    {
        int deep = 0;
        Vector3Int finalPos = startPos;

        while (deep < MAXDEEP) 
        {
            if (block.CanPushTo(this._gravityVector * (deep+1)))
            {
                deep++;
                finalPos = finalPos + this._gravityVector;
            }
            else
            {
                break;
            }
        }

        return finalPos;
    }


    public void GravityApply(LevelGrid levelGrid)
    {
        if (this._gravityVector == Vector3Int.zero) 
        {
            return;
        }

        List<Vector3Int> positions = new List<Vector3Int>();

        foreach (Vector3Int pos in levelGrid.GetAllPositions())
        {
            positions.Add(pos);
        }

        positions = SortByGravity(this._gravityVector, positions);
        List<Block> blocks = new List<Block>();
        for (int i = positions.Count - 1; i >= 0; i--)
        {
            List<Block> blocksAtPos;
            levelGrid.CheckBlockAt(positions[i], out blocksAtPos);
            for (int j = 0; j < blocksAtPos.Count; j++)
            {
                if (blocksAtPos[j] is IMovable block)
                {
                    Vector3Int newPos = FindFallFinalPosition(block, positions[i]);
                    if (newPos != positions[i])
                    {
                        if (block is Entity block2)
                        {
                            block2.MoveTo(newPos - positions[i]);
                        }
                        else
                        {
                            block.MoveTo(newPos - positions[i]);
                        }
                    }
                }
            }
        }
    }


    private List<Vector3Int> SortByGravity(Vector3Int gravity, List<Vector3Int> positions)
    {
        if (gravity.x != 0)
        {
            if (gravity.x > 0)
                positions.Sort((a, b) => a.x.CompareTo(b.x));
            else
                positions.Sort((a, b) => b.x.CompareTo(a.x));
        }
        else if (gravity.y != 0)
        {
            if (gravity.y > 0)
                positions.Sort((a, b) => a.y.CompareTo(b.y));
            else
                positions.Sort((a, b) => b.y.CompareTo(a.y));
        }
        else if (gravity.z != 0)
        {
            if (gravity.z > 0)
                positions.Sort((a, b) => a.z.CompareTo(b.z));
            else
                positions.Sort((a, b) => b.z.CompareTo(a.z));
        }
        return positions;
    }
}
