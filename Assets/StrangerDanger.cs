using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StrangerDanger : MonoBehaviour
{
    public TextMeshProUGUI iSeeText;
    public float delayBeforeLoad = 1.2f;

    void Start()
    {
        if (iSeeText != null)
            iSeeText.gameObject.SetActive(false);
    }

    public void OnStrangerDangerClicked()
    {
        if (iSeeText != null)
            iSeeText.gameObject.SetActive(true);

        // Load scene after a short delay (optional)
        Invoke(nameof(LoadGameplay), delayBeforeLoad);
    }

    void LoadGameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
