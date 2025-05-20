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
    public TextMeshProUGUI liarText; // Reference to "LIAR" text
    public GameObject beer; // Reference to "Beer" GameObject

    void Awake()
    {
        if (finalMessage != null)
            finalMessage.SetActive(false);

        if (liarText != null)
            liarText.gameObject.SetActive(false);

        if (fadeImage != null)
        {
            Color c = fadeImage.color;
            c.a = 0f;
            fadeImage.color = c;
        }
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
        if (beer != null)
            beer.SetActive(false); // Hide "Beer"

        if (liarText != null)
            liarText.gameObject.SetActive(true);

        StartCoroutine(FadeAndLoadGameplay());
    }

    IEnumerator FadeAndLoadGameplay()
    {
        AudioManager.instance.PlaySFX("Boom", 1f, 0.6f);
        AudioManager.instance.PlaySFX("Wood", 1f, 1.5f);
        AudioManager.instance.PlaySFX("Glass", 1f, 1.3f);

        yield return new WaitForSeconds(1.2f); // Wait to let SFX play

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
