using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class transitionGameplay : MonoBehaviour
{
    public Image fadeImage; // Fullscreen black UI Image
    public float fadeDuration = 1f;
    public CameraSwitcher cameraSwitcher; // Reference to camera switcher

    private bool isTransitioning = false;

    void Start()
    {
        // Ensure image is fully transparent at start
        if (fadeImage != null)
        {
            Color c = fadeImage.color;
            c.a = 0f;
            fadeImage.color = c;
        }
    }

    void Update()
    {
        // Wait for camera switch to be completed
        if (!isTransitioning && cameraSwitcher != null && cameraSwitcher.HasSwitched())
        {
            StartCoroutine(FadeAndLoad());
        }
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
