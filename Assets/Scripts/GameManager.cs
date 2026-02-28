using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Score")]
    public int score = 0;
    private bool gameEnded = false;

    [Header("HUD UI")]
    [SerializeField] private CoinCounterUI coinCounterUI;

    [Header("Settings Menu")]
    [SerializeField] private SettingsMenu settingsMenu;

    private int coinsRemaining;

    private void Start()
    {
        coinsRemaining = GameObject.FindGameObjectsWithTag("Coin").Length;

        if (coinCounterUI != null)
            coinCounterUI.UpdateScore(score);
    }

    public void AddCoin(int amount)
    {
        if (gameEnded) return;

        score += amount;
        coinsRemaining--;

        if (coinCounterUI != null) coinCounterUI.UpdateScore(score);

        if (coinsRemaining <= 0)
        {
            gameEnded = true;

            if (settingsMenu != null)
                settingsMenu.ShowMenu(true);
        }
    }
}
