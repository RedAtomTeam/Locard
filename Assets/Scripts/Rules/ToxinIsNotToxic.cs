using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxinIsNotToxic : LevelRule
{
    public override void DoRule(Context context)
    {
        foreach (Entity block in ((NounCommandBlock)commandBlocksLine[0]).targetNoun)
        {
            block.IsToxic = false;
        }
    }

    public override object Copy()
    {
        return MemberwiseClone();
    }
}
