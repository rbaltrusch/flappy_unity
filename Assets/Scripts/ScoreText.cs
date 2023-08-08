using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{

    [SerializeField] private Text text;
    [SerializeField] private Player player;

    private void Start()
    {
        RegisterScoreIncreaseHandler();
    }

    private void RegisterScoreIncreaseHandler()
    {
        player.ScoreIncrease += (sender, args) => { OnScoreIncrease(args); };
    }

    public void OnScoreIncrease(ScoreIncreaseArgs args)
    {
        Debug.Log(string.Format("received ScoreIncrease event with score: %s"));
        text.text = args.score.ToString();
    }
}