using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockIsViscous : LevelRule
{
    public override void DoRule(Context context)
    {
        foreach (Entity block in ((NounCommandBlock)commandBlocksLine[0]).targetNoun)
        {
            block.Collidable = CollideStatus.Viscous;
        }
    }

    public override object Copy()
    {
        return MemberwiseClone();
    }
}
