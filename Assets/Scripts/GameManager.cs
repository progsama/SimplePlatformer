using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;

    [SerializeField] private CoinCounterUI coinCounterUI;

    public void AddCoin(int amount)
    {
        score += amount;

        if (coinCounterUI != null)
            coinCounterUI.UpdateScore(score);
    }
}
