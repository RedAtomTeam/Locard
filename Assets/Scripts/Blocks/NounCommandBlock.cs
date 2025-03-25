using System.Collections.Generic;


public class NounCommandBlock : CommandBlock
{
    public List<Entity> targetNoun;

    public override bool Equals(CommandBlock obj)
    {
        if (obj is NounCommandBlock other)
        {
            if (obj.gameObject.name == this.gameObject.name)
            {
                return true;
            }
        }
        return false;
    }
}
