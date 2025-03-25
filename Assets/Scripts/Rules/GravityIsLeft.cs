using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityIsLeft : LevelRule
{
    public override void DoRule(Context context)
    {
        context._levelController.physicProcessor._gravityVector = new Vector3Int(0, 0, 1);
        context._levelController.physicProcessor.GravityApply(context._levelGrid);
    }

    public override object Copy()
    {
        return MemberwiseClone();
    }
}
