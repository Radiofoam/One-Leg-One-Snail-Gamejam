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
    public GameObject therapyButtonGroup;       // << Reference to "TherapyButtonGroup"

    void Awake()
    {
 

        if (trustTier2 != null)
            trustTier2.SetActive(false);

        if (triviaText != null)
            triviaText.gameObject.SetActive(false);

        if (proveYourselfText != null)
            proveYourselfText.gameObject.SetActive(false);

        if (therapyButtonGroup != null)
            therapyButtonGroup.SetActive(false); // Hide therapy group on start
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
            proveYourselfText.gameObject.SetActive(false); //Hide when tier1 closes
    }

    public void OnIncorrectClicked()
    {
        if (proveYourselfText != null)
            proveYourselfText.gameObject.SetActive(false); //Hide on incorrect too

        StartCoroutine(FadeAndLoadScene());
    }


    IEnumerator FadeAndLoadScene()
    {
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
