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
    [SerializeField] private Image gameover_background;
    [SerializeField] private TextMeshProUGUI gameover_score;

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

        FadeScreen(1f, 4f);
    }

    private void FadeScreen(float desired_alpha, float interval)
    {
        Color color = gameover_background.color;
        color.a = 1f;
        gameover_background.color = color;

        gameover_background.CrossFadeAlpha(0f, 0f, true);

        gameover_background.CrossFadeAlpha(desired_alpha, interval, false);
    }
}
