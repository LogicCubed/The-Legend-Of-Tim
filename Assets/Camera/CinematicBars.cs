using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CinematicBars : MonoBehaviour
{
    public RectTransform topBar;
    public RectTransform bottomBar;
    private float animationDuration = 0.25f;

    public GameObject UI;

    private Vector2 topBarOriginalPos;
    private Vector2 bottomBarOriginalPos;

    void Start()
    {
        // Store original positions
        topBarOriginalPos = topBar.anchoredPosition;
        bottomBarOriginalPos = bottomBar.anchoredPosition;
    }

    public void EnableBars()
    {
        StartCoroutine(MoveBars(topBarOriginalPos.y - 200, bottomBarOriginalPos.y + 200));
        UI.SetActive(false);
    }

    public void DisableBars()
    {
        StartCoroutine(MoveBars(topBarOriginalPos.y, bottomBarOriginalPos.y));
        UI.SetActive(true);
    }

    private IEnumerator MoveBars(float topTargetY, float bottomTargetY)
    {
        float elapsedTime = 0f;
        Vector2 topStart = topBar.anchoredPosition;
        Vector2 bottomStart = bottomBar.anchoredPosition;

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / animationDuration;
            topBar.anchoredPosition = new Vector2(topStart.x, Mathf.Lerp(topStart.y, topTargetY, t));
            bottomBar.anchoredPosition = new Vector2(bottomStart.x, Mathf.Lerp(bottomStart.y, bottomTargetY, t));
            yield return null;
        }

        // Ensure exact final position
        topBar.anchoredPosition = new Vector2(topStart.x, topTargetY);
        bottomBar.anchoredPosition = new Vector2(bottomStart.x, bottomTargetY);
    }
}
