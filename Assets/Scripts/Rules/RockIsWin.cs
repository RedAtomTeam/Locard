using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockIsWin : LevelRule
{
    public override void DoRule(Context context)
    {
        if (context._inputHandler.Controllable.gameObject.name == "Rock")
        {
            context._levelController.Win("You Is Win");
        }
    }

    public override object Copy()
    {
        return MemberwiseClone();
    }
}
