using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TrustTier2Handler : MonoBehaviour
{
    public GameObject trustTier2;
    public GameObject trustTier3;
    public Image fadeImage; // Fullscreen black UI Image
    public float fadeDuration = 1f;

    public TextMeshProUGUI triviaText; // Reference to "Trivia"
    public TextMeshProUGUI beerText;   // Reference to "Beer"

    void Awake()
    {
        if (trustTier2 != null)
            trustTier2.SetActive(false); //Now hides itself on awake

        if (trustTier3 != null)
            trustTier3.SetActive(false);

        if (beerText != null)
            beerText.gameObject.SetActive(false);

        if (triviaText != null)
            triviaText.gameObject.SetActive(false);

        if (fadeImage != null)
        {
            Color c = fadeImage.color;
            c.a = 0f;
            fadeImage.color = c;
        }
    }

    public void OnCorrectPressed()
    {
        if (triviaText != null)
            triviaText.gameObject.SetActive(false);

        if (trustTier2 != null)
            trustTier2.SetActive(false);

        if (trustTier3 != null)
            trustTier3.SetActive(true);

        if (beerText != null)
            beerText.gameObject.SetActive(true);
    }

    public void OnIncorrectPressed()
    {
        if (triviaText != null)
            triviaText.gameObject.SetActive(false);

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
