using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpManager : MonoBehaviour
{
    public GameObject PopUp;
    public TextMeshProUGUI PopUpTitle;
    public TextMeshProUGUI PopUpText;
    public Image PopUpImage;
    public Image PopUpGrade;

    private float popUpDuration = 4f;
    private float popUpTimer;

    void Start()
    {
    }

    void Update()
    {
        PopUpTimer();
    }

    public void ShowPopUp(string title, string message, Sprite ItemSprite, Sprite ItemGrade)
    {
        PopUpTitle.text = title;
        PopUpText.text = message;
        PopUpImage.sprite = ItemSprite;
        PopUpGrade.sprite = ItemGrade;

        PopUp.SetActive(true);
        popUpTimer = popUpDuration;
    }

    public void PopUpTimer()
    {
        if (popUpTimer > 0)
        {
            popUpTimer -= Time.deltaTime;

            if (popUpTimer <= 0)
            {
                PopUp.gameObject.SetActive(false);
            }
        }
    }
}
