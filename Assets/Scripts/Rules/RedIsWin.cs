using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedIsWin : LevelRule
{
    public override void DoRule(Context context)
    {
        if (context._inputHandler.Controllable.gameObject.GetComponent<Renderer>().material.color == new Color(1f, 0f, 0f))
        {
            context._levelController.Win("You Is Win");
        }
    }

    public override object Copy()
    {
        return MemberwiseClone();
    }
}
