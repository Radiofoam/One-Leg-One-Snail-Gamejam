using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class fadeIn : MonoBehaviour
{
    public float fadeDuration = 1f;

    private Image fadeImage;

    void Start()
    {
        fadeImage = GetComponent<Image>();

        if (fadeImage != null)
        {
            // Start fully black
            Color c = fadeImage.color;
            c.a = 1f;
            fadeImage.color = c;

            // Start fade-in
            StartCoroutine(FadeIn());
        }
    }

    IEnumerator FadeIn()
    {
        float timer = 0f;
        Color c = fadeImage.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            c.a = 1f - Mathf.Clamp01(timer / fadeDuration);
            fadeImage.color = c;
            yield return null;
        }

        // Ensure it's fully transparent
        c.a = 0f;
        fadeImage.color = c;
    }
}
