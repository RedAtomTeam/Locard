using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouIsRed : LevelRule
{
    public override void DoRule(Context context)
    {
        context._inputHandler.Controllable.ChangeColor(new Color(1f, 0f, 0f));
    }

    public override object Copy()
    {
        return MemberwiseClone();
    }
}
