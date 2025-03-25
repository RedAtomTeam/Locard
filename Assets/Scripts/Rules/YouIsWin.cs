using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouIsWin : LevelRule
{
    public override void DoRule(Context context)
    {
        context._levelController.Win("You Is Win");
    }

    public override object Copy()
    {
        return MemberwiseClone();
    }
}
