using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityIsNull : LevelRule
{
    public override void DoRule(Context context)
    {
        context._levelController.physicProcessor._gravityVector = new Vector3Int(0, 0, 0);
    }

    public override object Copy()
    {
        return MemberwiseClone();
    }
}
