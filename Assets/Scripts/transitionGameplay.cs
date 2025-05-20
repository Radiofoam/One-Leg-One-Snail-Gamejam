using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class transitionGameplay : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;
    public ParticleSystem explosion; // Show right before Boom

    void Start()
    {
        if (fadeImage != null)
        {
            Color c = fadeImage.color;
            c.a = 0f;
            fadeImage.color = c;
        }

        if (explosion != null)
            explosion.gameObject.SetActive(false); // hide on start
    }

    public void BeginFadeAndLoad()
    {
        StartCoroutine(FadeAndLoadScene());
    }

    IEnumerator FadeAndLoadScene()
    {
        // Show explosion before Boom
        if (explosion != null)
        {
            explosion.gameObject.SetActive(true);
            explosion.Play();
        }

        // Play SFX
        AudioManager.instance.PlaySFX("Boom", 1f, 0.6f);
        AudioManager.instance.PlaySFX("Wood", 1f, 1.5f);
        AudioManager.instance.PlaySFX("Glass", 1f, 1.3f);

        yield return new WaitForSeconds(1.5f); // Allow SFX to play

        // Fade to black
        if (fadeImage != null)
        {
            float timer = 0f;
            Color c = fadeImage.color;

            while (timer < fadeDuration)
            {
                timer += Time.deltaTime;
                c.a = Mathf.Clamp01(timer / fadeDuration);
                fadeImage.color = c;
                yield return null;
            }
        }

        SceneManager.LoadScene("Gameplay");
    }
}
