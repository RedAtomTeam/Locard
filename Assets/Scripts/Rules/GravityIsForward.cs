using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityIsForward : LevelRule
{
    public override void DoRule(Context context)
    {
        context._levelController.physicProcessor._gravityVector = new Vector3Int(1, 0, 0);
        context._levelController.physicProcessor.GravityApply(context._levelGrid);
    }

    public override object Copy()
    {
        return MemberwiseClone();
    }
}