using UnityEngine;

public class Scorer : MonoBehaviour
{
    private int score = 0;

    public void AddScore(int value)
    {
        if(value < 0) return;
        score += value;
        GameManager.instance.uIManager.UpdateScoreText(score);
    }
}