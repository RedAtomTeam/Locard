using System.Collections.Generic;
using UnityEngine;

public class LifeChecker : MonoBehaviour
{
    public static bool IsLive(Entity obj, LevelGrid grid, out string reason)
    {
        reason = "";

        Collider[] colliders = Physics.OverlapSphere(obj.Pos, 0.7f);
        foreach (Collider col in colliders)
        {
            if (col.tag == "DEATH")
            {
                reason = "You = Fly Away";
                return false;
            }
        }

        List<Block> blocks;
        if(grid.CheckBlockAt(obj.Pos, out blocks))
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                if (blocks[i] is Entity ent)
                {
                    if (ent.IsDamaging || ent.IsHot || ent.IsToxic)
                    {
                        if (obj.Collidable != CollideStatus.Intangible && ent.Collidable != CollideStatus.Intangible)
                        {
                            if (ent.IsDamaging)
                            {
                                reason = "You = Died";
                            }
                            if (ent.IsToxic)
                            {
                                reason = "You = Poisoned";
                            }
                            if (ent.IsHot)
                            {
                                reason = "You = Burned";
                            }
                            
                            return false;
                        }
                    }
                }
            }
        }
        return true;
    }
}
