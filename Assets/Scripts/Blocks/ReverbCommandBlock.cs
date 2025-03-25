

public class ReverbCommandBlock : CommandBlock
{
    public Verb targetVerb;
    public override bool Equals(CommandBlock obj)
    {
        if (obj is ReverbCommandBlock other)
        {
            return this.targetVerb == other.targetVerb;
        }
        return false;
    }
}


public enum Verb
{
    IS
}