using UnityEngine;
using TMPro;

public class isSnailToo : MonoBehaviour
{
    public GameObject trustTier1;
    public TextMeshProUGUI iSeeText;

    void Start()
    {
        if (trustTier1 != null)
            trustTier1.SetActive(false);

        if (iSeeText != null)
            iSeeText.gameObject.SetActive(false);
    }

    public void OnSnailButtonClicked()
    {
        if (trustTier1 != null)
            trustTier1.SetActive(true);

        if (iSeeText != null)
            iSeeText.gameObject.SetActive(true);
    }
}
