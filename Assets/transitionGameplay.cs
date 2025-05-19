using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class transitionGameplay : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;
    private bool isTransitioning = false;

    void Start()
    {
        if (fadeImage != null)
        {
            Color c = fadeImage.color;
            c.a = 0f;
            fadeImage.color = c;
        }
    }

    public void BeginFadeAndLoad()
    {
        if (!isTransitioning)
            StartCoroutine(FadeAndLoad());
    }

    IEnumerator FadeAndLoad()
    {
        isTransitioning = true;

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
