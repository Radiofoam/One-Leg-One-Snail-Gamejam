using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TrustTier1 : MonoBehaviour
{
    public GameObject trustTier1;
    public GameObject trustTier2;
    public Image fadeImage;
    public float fadeDuration = 1f;

    public TextMeshProUGUI triviaText;          // "Trivia"
    public TextMeshProUGUI proveYourselfText;   // "Prove yourself"
    public GameObject therapyButtonGroup;       // "TherapyButtonGroup"
    public ParticleSystem explosion;            // Explosion particle system

    void Awake()
    {
        if (trustTier2 != null)
            trustTier2.SetActive(false);

        if (triviaText != null)
            triviaText.gameObject.SetActive(false);

        if (proveYourselfText != null)
            proveYourselfText.gameObject.SetActive(false);

        if (therapyButtonGroup != null)
            therapyButtonGroup.SetActive(false);

        if (explosion != null)
            explosion.gameObject.SetActive(false); // Hide explosion at start
    }

    public void OnCorrectClicked()
    {
        if (trustTier1 != null)
            trustTier1.SetActive(false);

        if (trustTier2 != null)
            trustTier2.SetActive(true);

        if (triviaText != null)
            triviaText.gameObject.SetActive(true);

        if (proveYourselfText != null)
            proveYourselfText.gameObject.SetActive(false);
    }

    public void OnIncorrectClicked()
    {
        if (proveYourselfText != null)
            proveYourselfText.gameObject.SetActive(false);

        StartCoroutine(FadeAndLoadScene());
    }

    IEnumerator FadeAndLoadScene()
    {
        // Play explosion before SFX
        if (explosion != null)
        {
            explosion.gameObject.SetActive(true);
            explosion.Play();
        }

        // Play SFX
        AudioManager.instance.PlaySFX("Boom", 1f, 0.6f);
        AudioManager.instance.PlaySFX("Wood", 1f, 1.5f);
        AudioManager.instance.PlaySFX("Glass", 1f, 1.3f);

        yield return new WaitForSeconds(1.5f);

        // Fade to black
        if (fadeImage != null)
        {
            float timer = 0f;
            Color c = fadeImage.color;
            c.a = 0f;
            fadeImage.color = c;

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
