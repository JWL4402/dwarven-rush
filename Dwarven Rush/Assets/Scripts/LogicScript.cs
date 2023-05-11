using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    private int score;
    [SerializeField]
    private TextMeshProUGUI scoreboard;

    public enum GameState
    {
        ACTIVE,
        GAME_OVER
    }

    [ContextMenu("Add Score")]
    public void AddScore(int score_increment = 1)
    {
        
        score += score_increment;
        scoreboard.text = score.ToString();
    }

    public void ChangeGameState(GameState game_state)
    {

    }
}
