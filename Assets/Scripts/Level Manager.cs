using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public TextMeshProUGUI BarrelCount;

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
        //scoreBarrelCount.text = gameScore + "";
    }
}
