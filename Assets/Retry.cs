using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public GameObject retryButton; // Assign this in the Inspector

    private void Awake()
    {
        if (retryButton != null)
            retryButton.SetActive(false); // Hide on Awake
    }

    public void OnRestartButtonClicked()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
