using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouIsFloat : LevelRule
{
    public override void DoRule(Context context)
    {
        context._inputHandler.Controllable.Collidable = CollideStatus.Intangible;
        print($"Set Object CollidableStatus: {context._inputHandler.Controllable.Collidable}");
    }

    public override object Copy()
    {
        return MemberwiseClone();
    }
}
