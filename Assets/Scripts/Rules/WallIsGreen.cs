using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallIsGreen : LevelRule
{
    public override void DoRule(Context context)
    {
        foreach (Entity block in ((NounCommandBlock)commandBlocksLine[0]).targetNoun)
        {
            block.ChangeColor(new Color(0f, 1f, 0f));
        }
    }

    public override object Copy()
    {
        return MemberwiseClone();
    }
}
