using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TrustTier3Handler : MonoBehaviour
{
    public GameObject trustTier3;
    public GameObject finalMessage;
    public Image fadeImage;
    public float fadeDuration = 1f;

    public TextMeshProUGUI liarText; // Assign "LIAR" TextMeshPro in Inspector

    void Awake()
    {
        if (finalMessage != null)
            finalMessage.SetActive(false);

        if (fadeImage != null)
        {
            Color c = fadeImage.color;
            c.a = 0f;
            fadeImage.color = c;
        }
    }

    void OnEnable()
    {
        // This runs when the object becomes active
        if (liarText != null)
            liarText.gameObject.SetActive(false); // Hide LIAR each time this script is re-enabled
    }

    public void OnCorrectPressed()
    {
        if (trustTier3 != null)
            trustTier3.SetActive(false);

        if (finalMessage != null)
            finalMessage.SetActive(true);
    }

    public void OnIncorrectPressed()
    {
        if (liarText != null)
            liarText.gameObject.SetActive(true); // Show "LIAR"

        StartCoroutine(FadeAndLoadGameplay());
    }

    IEnumerator FadeAndLoadGameplay()
    {
        if (fadeImage == null)
        {
            SceneManager.LoadScene("Gameplay");
            yield break;
        }

        float timer = 0f;
        Color c = fadeImage.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            c.a = Mathf.Clamp01(timer / fadeDuration);
            fadeImage.color = c;
            yield return null;
        }

        SceneManager.LoadScene("Gameplay");
    }
}
