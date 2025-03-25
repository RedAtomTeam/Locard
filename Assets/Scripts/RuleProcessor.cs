using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

// Класс исполнитель правил
public class RuleProcessor
{
    private Context _context;

    public RuleProcessor(Context context)
    {
        this._context = context;
    }

    // Выполняем все правила
    public void ApplyRules(List<ILevelRule> rulesToDo)
    {
        for (int i = 0; i < rulesToDo.Count; i++)
        {
            rulesToDo[i].DoRule(this._context);
        }
    }
}
