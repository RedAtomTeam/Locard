using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouIsGreen : LevelRule
{
    public override void DoRule(Context context)
    {
        context._inputHandler.Controllable.ChangeColor(new Color(0f, 1f, 0f));
    }

    public override object Copy()
    {
        return MemberwiseClone();
    }
}
