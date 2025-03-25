using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueIsViscous : LevelRule
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
                    if (entBlock.gameObject.GetComponent<Renderer>().material.color == new Color(0f, 0f, 1f))
                    {
                        entBlock.Collidable = CollideStatus.Viscous;
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
