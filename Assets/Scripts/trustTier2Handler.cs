using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TrustTier2Handler : MonoBehaviour
{
    public GameObject trustTier2;
    public GameObject trustTier3;
    public Image fadeImage;
    public float fadeDuration = 1f;

    public TextMeshProUGUI triviaText;
    public TextMeshProUGUI beerText;
    public ParticleSystem explosion; // Particle explosion

    void Awake()
    {
        if (trustTier2 != null)
            trustTier2.SetActive(false);

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

        if (explosion != null)
            explosion.gameObject.SetActive(false); // Hide explosion on start
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
        // Play explosion effect
        if (explosion != null)
        {
            explosion.gameObject.SetActive(true);
            explosion.Play();
        }

        // Play SFX
        AudioManager.instance.PlaySFX("Boom", 1f, 0.6f);
        AudioManager.instance.PlaySFX("Wood", 1f, 1.5f);
        AudioManager.instance.PlaySFX("Glass", 1f, 1.3f);

        yield return new WaitForSeconds(1.2f); // Let SFX play before fading

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
