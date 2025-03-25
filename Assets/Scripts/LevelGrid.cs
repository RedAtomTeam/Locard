using System.Collections.Generic;
using UnityEngine;


public class LevelGrid
{
    private Dictionary<Vector3Int, List<Block>> _grid = new Dictionary<Vector3Int, List<Block>>();


    public LevelGrid(List<Block> blocks)
    {
        foreach (Block block in blocks)
        {
            this.PlaceBlock(block);
            block.SetDefaultState();
        }
    }


    public void PlaceBlock(Block block)
    {
        block.Pos = new Vector3Int((int)block.transform.position.x, (int)block.transform.position.y, (int)block.transform.position.z);
        if (!this._grid.ContainsKey(block.Pos))
        {
            this._grid[block.Pos] = new List<Block>();
        }
        this._grid[block.Pos].Add(block);
        block.LevelGrid = this;
    }


    public void UpdateBlocks()
    {
        List<Vector3Int> keys = new List<Vector3Int>(this._grid.Keys);
        List<Block> blocks1 = new List<Block>();
        foreach (Vector3Int key in keys)
        {
            foreach (Block block in this._grid[key])
            {
                blocks1.Add(block);
            }
            this._grid.Remove(key);
        }

        foreach (Block block in blocks1)
        {
            this.PlaceBlock(block);
            block.SetDefaultState();
        }
    }

    public void UpdateBlocksState()
    {
        List<Vector3Int> keys = new List<Vector3Int>(this._grid.Keys);
        List<Block> blocks1 = new List<Block>();
        foreach (Vector3Int key in keys)
        {
            foreach (Block block in this._grid[key])
            { 
                block.SetDefaultState();
            }
        }
    }


    public void UpdateBlock(Block block, Vector3Int oldPos)
    {
        for (int i = 0; i < this._grid[oldPos].Count; i++)
        {
            if (this._grid[oldPos][i] == block)
            {
                this._grid[oldPos].Remove(block);
                break;
            }
        }

        if (!this._grid.ContainsKey(block.Pos))
        {
            this._grid[block.Pos] = new List<Block>();
        }
        this._grid[block.Pos].Add(block);
    }


    public void RemoveBlock(Block block)
    {
        if (this._grid.ContainsKey(block.Pos))
        {
            for (int i = 0; i < this._grid[block.Pos].Count; i++)
            {
                if (this._grid[block.Pos][i].GetHashCode() == block.GetHashCode())
                {
                    this._grid[block.Pos].Remove(block);
                    block.Die();
                }
            }
        }
    }


    public bool CheckBlockAt(Vector3Int position, out List<Block> blocks)
    {
        if (this._grid.ContainsKey(position))
        {
            blocks = this._grid[position];
            return true;
        }
        blocks = null;
        return false;
    }


    public IEnumerable<Vector3Int> GetAllPositions()
    {
        return this._grid.Keys;
    }
}
