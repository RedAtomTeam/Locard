using System.Collections.Generic;
using UnityEngine;

public class LevelRule : MonoBehaviour, ILevelRule
{
    public List<CommandBlock> commandBlocksLine;
    public List<CommandBlock> CommandBlocksLine { get => commandBlocksLine; set => commandBlocksLine = value; }

    public virtual void DoRule(Context context)
    {
        print("LevelRule");
    }

    public virtual object Copy()
    {
        return MemberwiseClone();
    }
}
