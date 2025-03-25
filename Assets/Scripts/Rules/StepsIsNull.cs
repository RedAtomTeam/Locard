using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsIsNull : LevelRule
{
    public override void DoRule(Context context)
    {
        context._levelController.steps = 0;
    }

    public override object Copy()
    {
        return MemberwiseClone();
    }
}
