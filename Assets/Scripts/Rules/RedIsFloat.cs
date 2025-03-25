using System.Collections.Generic;
using UnityEngine;

public class RedIsFloat : LevelRule
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
                    print(entBlock.gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color);
                    if (entBlock.gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color == new Color(1f, 0f, 0f))
                    {
                        entBlock.Collidable = CollideStatus.Intangible;
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
