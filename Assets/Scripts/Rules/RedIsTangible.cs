using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedIsTangible : LevelRule
{
    public override void DoRule(Context context)
    {
        foreach (var pos in context._levelGrid.GetAllPositions())
        {
            List<Block> blocks = new List<Block>();
            context._levelGrid.CheckBlockAt(pos, out blocks);
            foreach (Block block in blocks)
            {
                if (block is Entity entBlock)
                {
                    if (entBlock.gameObject.GetComponent<Renderer>().material.color == new Color(1f, 0f, 0f))
                    {
                        entBlock.Collidable = CollideStatus.Tangible;
                    }
                }
            }
        }
    }

    public override object Copy()
    {
        return MemberwiseClone();
    }
}
