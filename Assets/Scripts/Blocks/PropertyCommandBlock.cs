

public class PropertyCommandBlock : CommandBlock
{
    public Property targetProperty;

    public override bool Equals(CommandBlock obj)
    {
        if (obj is PropertyCommandBlock other)
        {
            return this.targetProperty == other.targetProperty;
        }
        return false;
    }
}

public enum Property
{
    Red,
    Green, 
    Blue, 
    Float,
    You,
    Win,
    Gravity,
    Left,
    Forward,
    Down,
    Null,
    Add,
    Sub,
    Multiply,
    Divide,
    Steps,
    MaxSteps,
    Not,
    Loose,
    Viscous,
    Tangible,
    Fixed,
    Unfixed,
    Damaged,
    Hot,
    Toxic
}