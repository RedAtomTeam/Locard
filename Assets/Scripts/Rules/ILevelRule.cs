using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelRule
{
    public List<CommandBlock> CommandBlocksLine { get; set; }


    public void DoRule(Context context)
    {

    }

    public virtual object Copy()
    {
        return null;
    }
}
