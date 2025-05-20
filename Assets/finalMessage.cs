using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinalMessageMonologue : MonoBehaviour
{
    public GameObject finalMessageParent; // Parent with all TextMeshPro children
    public float interval = 3f;
    public Image fadeImage;
    public float fadeDuration = 1f;
    public TextMeshProUGUI beerText; // Assign Beer TextMeshProUGUI in the Inspector

    private int currentIndex = 0;

    void Awake()
    {
        // Hide the entire monologue parent on Awake
        if (finalMessageParent != null)
            finalMessageParent.SetActive(false);
    }

    void Start()
    {
        if (finalMessageParent == null)
        {
            Debug.LogWarning("FinalMessageMonologue: finalMessageParent is not assigned.");
            return;
        }

        // Enable the parent and hide all its children
        finalMessageParent.SetActive(true);
        foreach (Transform child in finalMessageParent.transform)
        {
            child.gameObject.SetActive(false);
        }

        StartCoroutine(PlayMonologue());
    }

    IEnumerator PlayMonologue()
    {
        int childCount = finalMessageParent.transform.childCount;

        while (currentIndex < childCount)
        {
            // Hide all messages
            foreach (Transform child in finalMessageParent.transform)
            {
                child.gameObject.SetActive(false);
            }

            // Show the current message
            Transform currentChild = finalMessageParent.transform.GetChild(currentIndex);
            currentChild.gameObject.SetActive(true);

            // When showing the first message, hide the Beer text
            if (currentIndex == 0 && beerText != null)
            {
                beerText.gameObject.SetActive(false);
            }

            // On final message (index 2), also start fade to black
            if (currentIndex == 2 && fadeImage != null)
            {
                StartCoroutine(FadeToBlack());
            }

            currentIndex++;
            yield return new WaitForSeconds(interval);
        }
    }

    IEnumerator FadeToBlack()
    {
        if (fadeImage == null)
            yield break;

        Color c = fadeImage.color;
        c.a = 0f;
        fadeImage.color = c;

        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            c.a = Mathf.Clamp01(timer / fadeDuration);
            fadeImage.color = c;
            yield return null;
        }
    }
}
