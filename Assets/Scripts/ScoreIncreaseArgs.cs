using System;

public class ScoreIncreaseArgs : EventArgs
{
    public readonly int score;

    public ScoreIncreaseArgs(int score)
    {
        this.score = score;
    }
}
