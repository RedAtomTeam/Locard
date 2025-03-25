using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouIsViscous : LevelRule
{
    public override void DoRule(Context context)
    {
        context._inputHandler.Controllable.Collidable = CollideStatus.Viscous;
    }

    public override object Copy()
    {
        return MemberwiseClone();
    }
}
