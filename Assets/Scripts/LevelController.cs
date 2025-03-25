using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class LevelController : MonoBehaviour
{
    [SerializeField] private List<Block> _blocks = new List<Block>();
    [SerializeField] private List<LevelRule> _rules = new List<LevelRule>();
    [SerializeField] private UIController _controller;
    [SerializeField] private GameObject parentOfBlocks;


    private LevelGrid _levelGrid;
    private RuleParser _ruleParser;
    private RuleProcessor _ruleProcessor;

    public PhysicProcessor physicProcessor { get; private set; }
    public InputHandler inputHandler;
    public int steps = 0;
    public int maxSteps;


    void Start()
    {
        for (int i = 0; i < this.parentOfBlocks.gameObject.transform.childCount; i++)
        {
            _blocks.Add(this.parentOfBlocks.gameObject.transform.GetChild(i).GetComponent<Block>());
        } 

        this._controller.UpdateSteps(this.steps, this.maxSteps);
        this._levelGrid = new LevelGrid(this._blocks);
        this._ruleParser = new RuleParser(this._levelGrid, this._rules);
        this._ruleProcessor = new RuleProcessor(new Context(this, this._levelGrid, this.inputHandler));
        this.physicProcessor = new PhysicProcessor(new Vector3Int(0, -1, 0));
    }


    public void Win(string winText)
    {
        if (GameDataManager.Instance != null)
        {
            for (int i = 1; i < GameDataManager.Instance.playerGameData._levels.Count; i++)
            {
                if (GameDataManager.Instance.playerGameData._levels[i-1]._name == SceneManager.GetActiveScene().name)
                {
                    GameDataManager.Instance.playerGameData._levels[i]._open = true;
                    break;
                }
            }
        }
        this._controller.Win(winText);
        GameDataManager.Instance.SaveGameData("GameData");
    }


    public void Loose (string reason)
    {
        this.inputHandler.gameObject.SetActive(false);
        this._controller.Loose(reason);
    }


    public void EndTurn()
    {
        DOTween.CompleteAll();
        this.steps = this.steps + 1;
        this._levelGrid.UpdateBlocksState();
        this._controller.UpdateSteps(this.steps, this.maxSteps);
        this._ruleProcessor.ApplyRules(this._ruleParser.ParseRules());
        this.physicProcessor.GravityApply(this._levelGrid);
        this._ruleProcessor.ApplyRules(this._ruleParser.ParseRules());
        this._controller.UpdateSteps(this.steps, this.maxSteps);

        string reason;
        if (!LifeChecker.IsLive(this.inputHandler.Controllable, this._levelGrid, out reason) || this.steps >= this.maxSteps)
        {
            if (this.steps >= this.maxSteps)
            {
                reason = "Steps = Over";
            }
            Loose(reason);
        }
    }
}
