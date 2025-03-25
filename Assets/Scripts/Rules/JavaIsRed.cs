using UnityEngine;

public class JavaIsRed : LevelRule
{
    public override void DoRule(Context context)
    {
        foreach (Entity block in ((NounCommandBlock)commandBlocksLine[0]).targetNoun)
        {
            block.ChangeColor(new Color(1f, 0f, 0f));
        }
    }

    public override object Copy()
    {
        return MemberwiseClone();
    }
}
