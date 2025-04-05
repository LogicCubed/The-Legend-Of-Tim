using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopUpManager : MonoBehaviour
{
    public GameObject PopUp;
    public TextMeshProUGUI PopUpTitle;
    public TextMeshProUGUI PopUpText;
    public Image PopUpImage;
    public Image PopUpGrade;

    private float popUpDuration = 4f;
    private float animationDuration = 0.1f;
    private Vector2 originalPosition;

    public LevelManager levelManager;

    void Start()
    {
        originalPosition = PopUp.GetComponent<RectTransform>().anchoredPosition;
    }

    public void ShowPopUp(string title, string message, Sprite ItemSprite, Sprite ItemGrade)
    {
        PopUpTitle.text = title;
        PopUpText.text = message;
        PopUpImage.sprite = ItemSprite;
        PopUpGrade.sprite = ItemGrade;

        PopUp.SetActive(true);
        levelManager.StartCoroutine(levelManager.HandleLevelBarAnimation());
        StartCoroutine(HandlePopUpAnimation());
    }

    private IEnumerator HandlePopUpAnimation()
    {
        yield return StartCoroutine(MovePopUp(originalPosition.y + 210));
        yield return new WaitForSeconds(popUpDuration);
        yield return StartCoroutine(MovePopUp(originalPosition.y));
        PopUp.SetActive(false);
    }

    private IEnumerator MovePopUp(float targetY)
    {
        float elapsedTime = 0f;
        RectTransform popUpRect = PopUp.GetComponent<RectTransform>();
        Vector2 startPos = popUpRect.anchoredPosition;

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / animationDuration;
            popUpRect.anchoredPosition = new Vector2(startPos.x, Mathf.Lerp(startPos.y, targetY, t));
            yield return null;
        }

        popUpRect.anchoredPosition = new Vector2(startPos.x, targetY);
    }
}
