namespace Semester2.Core;

public enum Direction
{
    None,
    North,
    East,
    South,
    West
}

public enum GameState
{
    None,
    Exploration,
    Combat,
    Dialogue
}

public enum ActionVerb
{
    None,
    Go,
    Take,
    Say
}