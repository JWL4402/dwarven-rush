using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public enum GameState
    {
        ACTIVE,
        GAME_OVER
    }

    public GameState state = GameState.ACTIVE;
    private int score;
    [SerializeField] private TextMeshProUGUI scoreboard;
    [SerializeField] private GameObject gameover;
    [SerializeField] private TextMeshProUGUI gameover_score;


    [ContextMenu("Add Score")]
    public void AddScore(int score_increment = 1)
    {
        score += score_increment;
        scoreboard.text = score.ToString();
    }

    [ContextMenu("End Game")]
    public void EndGame()
    {
        state = GameState.GAME_OVER;

        gameover_score.text = "Score : " + score;
        gameover.SetActive(true);
    }
}
