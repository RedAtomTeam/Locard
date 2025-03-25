using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueIsWin : LevelRule
{
    public override void DoRule(Context context)
    {
        if (context._inputHandler.Controllable.gameObject.GetComponent<Renderer>().material.color == new Color(0f, 0f, 1f))
        {
            context._levelController.Win("You Is Win");
        }
    }

    public override object Copy()
    {
        return MemberwiseClone();
    }
}
