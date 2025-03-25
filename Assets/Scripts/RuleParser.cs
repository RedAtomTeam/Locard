using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;


public class RuleParser
{
    private LevelGrid _levelGrid;

    private List<LevelRule> _rules;

    public RuleParser(LevelGrid levelGrid, List<LevelRule> rules)
    {
        this._rules = rules;
        this._levelGrid = levelGrid;
    }


    public List<ILevelRule> ParseRules()
    {
        List<ILevelRule> returnRules = new List<ILevelRule>();
        foreach (Vector3Int pos in this._levelGrid.GetAllPositions())
        {
            returnRules.AddRange(CheckSequence(pos, Vector3Int.back));
            returnRules.AddRange(CheckSequence(pos, Vector3Int.right));
            returnRules.AddRange(CheckSequence(pos, Vector3Int.down));
        }
        return returnRules;
    }


    private List<CommandBlock> GetLineBlocks(Vector3Int startPos, Vector3Int direction, int maxLength)
    {
        List<CommandBlock> lineBlocks = new List<CommandBlock>();

        Vector3Int currentPosition = startPos;
        for (int i = 0; i < maxLength; i++)
        {
            if (this._levelGrid.CheckBlockAt(currentPosition, out List<Block> blocksAtPosition) && blocksAtPosition.Count > 0)
            {
                bool findCommandBlock = false;
                foreach (var block in blocksAtPosition)
                {
                    if (block is CommandBlock)
                    {
                        lineBlocks.Add((CommandBlock)block);
                        findCommandBlock = true;
                        break;
                    }
                }
                if (!(findCommandBlock))
                {
                    break;
                }
            }
            else
            {
                break;
            }
            currentPosition += direction;
        }

        return lineBlocks;
    }


    private List<ILevelRule> CheckSequence(Vector3Int startPos, Vector3Int direction)
    {
        List<ILevelRule> returnRules = new List<ILevelRule>();
        int maxRuleLength = this._rules.Max(rule => rule.CommandBlocksLine.Count);
        List<CommandBlock> lineBlocks = GetLineBlocks(startPos, direction, maxRuleLength);

        foreach (ILevelRule rule in this._rules)
        {
            if (IsRuleMatch(rule, lineBlocks))
            {
                ILevelRule newRule = (ILevelRule)rule.Copy();
                newRule.CommandBlocksLine = lineBlocks;

                returnRules.Add(newRule);
            }
        }

        return returnRules;
    }


    private bool IsRuleMatch(ILevelRule rule, List<CommandBlock> blocks)
    {
        if (blocks.Count < rule.CommandBlocksLine.Count)
            return false;

        for (int i = 0; i < rule.CommandBlocksLine.Count; i++)
        {
            if (blocks[i].GetType() != rule.CommandBlocksLine[i].GetType())
            {
                return false;
            }
            else
            {
                if (!blocks[i].Equals(rule.CommandBlocksLine[i]))
                {
                    return false;
                }
            }
        }
        return true;
    }
}
