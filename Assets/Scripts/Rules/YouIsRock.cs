using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class YouIsRock : LevelRule
{

    public override void DoRule(Context context)
    {
        context._inputHandler.Controllable = (((NounCommandBlock)commandBlocksLine[2]).targetNoun[0]);
    }

    public override object Copy()
    {
        return MemberwiseClone();
    }
}
