using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavaIsTangible : LevelRule
{
    public override void DoRule(Context context)
    {
        foreach (Entity block in ((NounCommandBlock)commandBlocksLine[0]).targetNoun)
        {
            block.Collidable = CollideStatus.Tangible;
        }
    }

    public override object Copy()
    {
        return MemberwiseClone();
    }
}
