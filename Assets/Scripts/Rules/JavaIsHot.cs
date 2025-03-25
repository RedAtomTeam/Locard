using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavaIsHot : LevelRule
{
    public override void DoRule(Context context)
    {
        foreach (Entity block in ((NounCommandBlock)commandBlocksLine[0]).targetNoun)
        {
            block.IsHot = true;
        }
    }

    public override object Copy()
    {
        return MemberwiseClone();
    }
}
