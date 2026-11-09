using UnityEngine;
using TMPro;

public class CombatManager : MonoBehaviour
{
    public static CombatManager instance;
    
    public int Player1Score = 0;
    
    public int Player2Score = 0;

    public CombatController player1;

    public CombatController player2;

    public TextMeshProUGUI Player1Field;

    public TextMeshProUGUI Player2Field;
    private void Awake()
    {
        instance = this;
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }
    
    public void UpdateUI()
    {
        Player1Field.text = Player1Score.ToString() + " :: K-D: " + player1.KDRatio;
        //Player2Field.text = "" + Player2Score;
        Player2Field.text = Player2Score.ToString() + " :: K-D: " + player2.KDRatio;
    }

    public void AddScore(int playerNumber)
    {
        if (playerNumber == 1) {  Player1Score++; }

        if (playerNumber == 2) { Player2Score++; }
    }
}
