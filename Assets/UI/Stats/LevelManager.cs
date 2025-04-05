using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public GameObject LevelBar;

    private float popUpDuration = 4f;
    private float animationDuration = 0.1f;
    private Vector2 originalPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalPosition = LevelBar.GetComponent<RectTransform>().anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator HandleLevelBarAnimation()
    {
        yield return StartCoroutine(MoveLevelBar(originalPosition.y - 210));
        yield return new WaitForSeconds(popUpDuration);
        yield return StartCoroutine(MoveLevelBar(originalPosition.y));
        LevelBar.SetActive(true);
    }

    private IEnumerator MoveLevelBar(float targetY)
    {
        float elapsedTime = 0f;
        RectTransform levelBarRect = LevelBar.GetComponent<RectTransform>();
        Vector2 startPos = levelBarRect.anchoredPosition;

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / animationDuration;
            levelBarRect.anchoredPosition = new Vector2(startPos.x, Mathf.Lerp(startPos.y, targetY, t));
            yield return null;
        }

        levelBarRect.anchoredPosition = new Vector2(startPos.x, targetY);
    }
}
