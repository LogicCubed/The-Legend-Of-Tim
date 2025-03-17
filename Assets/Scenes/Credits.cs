using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour
{
    public float delayBeforeFade = 50f;  // Time to wait before fading back to Main Menu
    public GameObject credits;  // Reference to the Canvas that holds credits UI
    public RectTransform creditsRectTransform;  // RectTransform of the credits text (use this instead of GetComponent)

    private float totalHeight;
    private float screenHeight;

    void Start()
    {
        if (creditsRectTransform == null)
        {
            creditsRectTransform = credits.GetComponent<RectTransform>();  // Assign in inspector
        }

        totalHeight = creditsRectTransform.rect.height;  // Get the total height of the text
        screenHeight = Screen.height;  // Get the screen height for comparison

        credits.SetActive(false);  // Make sure the credits are hidden initially
    }

    void Update()
    {
        if (credits.activeSelf)
        {
            // Scroll the credits text upwards
            creditsRectTransform.anchoredPosition += new Vector2(0, 250 * Time.deltaTime);

            // Check if the credits have completely scrolled past the screen
            if (creditsRectTransform.anchoredPosition.y >= totalHeight + screenHeight)
            {
                StartCoroutine(FadeBackToMainMenu());
            }
        }
    }

    // Coroutine to handle fading back to the Main Menu after scrolling
    private IEnumerator FadeBackToMainMenu()
    {
        yield return new WaitForSeconds(delayBeforeFade);  // Wait before fading

        // Disable the credits canvas and return to the main menu
        credits.SetActive(false);  // Hide credits

        // Trigger Main Menu actions (e.g., load scene, show UI, etc.)
        // Uncomment the following line if you want to load the main menu scene
        // SceneManager.LoadScene("MainMenu");
    }

    // Call this method to show the credits
    public void ShowCredits()
    {
        credits.SetActive(true);  // Show the credits UI

        // Start the credits from just below the screen
        creditsRectTransform.anchoredPosition = new Vector2(0, -totalHeight);  // Start from just below the credits text
    }
}