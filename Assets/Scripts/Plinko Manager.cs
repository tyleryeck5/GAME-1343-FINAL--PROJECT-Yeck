using UnityEngine;
using TMPro;

public class PlinkoManager : MonoBehaviour
{
    public static PlinkoManager instance;

    public TextMeshProUGUI scoreField;

    int gameScore = 0;

    private void Awake()
    {
        instance = this;

        gameScore = 0;
    }

    public void AddScore(int value)
    {
        gameScore += value;
    }
    void Update()
    {
        scoreField.text = gameScore + "";
    }
}
