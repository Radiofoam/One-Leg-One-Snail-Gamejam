using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class StrangerDanger : MonoBehaviour
{
    public TextMeshProUGUI iSeeText;
    public Image fadeImage; // Fullscreen black UI Image (alpha 0 at start)
    public float fadeDuration = 1f;
    public ParticleSystem explosion; // Add particle system reference

    void Awake()
    {
        if (iSeeText != null)
            iSeeText.gameObject.SetActive(false);

        if (fadeImage != null)
        {
            Color c = fadeImage.color;
            c.a = 0f;
            fadeImage.color = c;
        }

        if (explosion != null)
            explosion.gameObject.SetActive(false); // Hide at start
    }

    public void OnStrangerDangerClicked()
    {
        if (iSeeText != null)
            iSeeText.gameObject.SetActive(true);

        StartCoroutine(FadeAndLoadScene());
    }

    IEnumerator FadeAndLoadScene()
    {
        // Show and play explosion before SFX
        if (explosion != null)
        {
            explosion.gameObject.SetActive(true);
            explosion.Play();
        }

        // Play SFX
        AudioManager.instance.PlaySFX("Boom", 1f, 0.6f);
        AudioManager.instance.PlaySFX("Wood", 1f, 1.5f);
        AudioManager.instance.PlaySFX("Glass", 1f, 1.3f);

        // Wait so SFX isn't cut off
        yield return new WaitForSeconds(1.5f);

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
