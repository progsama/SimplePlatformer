using System.Collections;
using TMPro;
using UnityEngine;

public class CoinCounterUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI current;
    [SerializeField] private TextMeshProUGUI toUpdate;
    [SerializeField] private RectTransform coinTextContainer;

    [Header("Animation")]
    [SerializeField] private float duration = 0.4f;
    [SerializeField] private AnimationCurve animationCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    private float containerInitY;
    private float moveAmount;
    private Coroutine animRoutine;

    private void Start()
    {
        Canvas.ForceUpdateCanvases();

        current.SetText("0");
        toUpdate.SetText("0");

        containerInitY = coinTextContainer.anchoredPosition.y;

        moveAmount = current.rectTransform.rect.height;
    }

    public void UpdateScore(int score)
    {
        toUpdate.SetText(score.ToString());

        if (animRoutine != null) StopCoroutine(animRoutine);
        animRoutine = StartCoroutine(AnimateAndSwap(score));
    }

    private IEnumerator AnimateAndSwap(int score)
    {
        float startY = containerInitY;
        float endY = containerInitY + moveAmount;

        float t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float p = Mathf.Clamp01(t / duration);
            float eased = animationCurve.Evaluate(p);

            float y = Mathf.LerpUnclamped(startY, endY, eased);
            coinTextContainer.anchoredPosition = new Vector2(coinTextContainer.anchoredPosition.x, y);

            yield return null;
        }

        coinTextContainer.anchoredPosition = new Vector2(coinTextContainer.anchoredPosition.x, endY);

        current.SetText(score.ToString());

        coinTextContainer.anchoredPosition = new Vector2(coinTextContainer.anchoredPosition.x, containerInitY);

        animRoutine = null;
    }
}
