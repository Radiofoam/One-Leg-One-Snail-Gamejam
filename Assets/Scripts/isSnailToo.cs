using UnityEngine;
using TMPro;

public class isSnailToo : MonoBehaviour
{
    public GameObject trustTier1;
    public TextMeshProUGUI iSeeText;
    public TextMeshProUGUI proveYourselfText; //Assign in Inspector

    void Awake()
    {
        if (trustTier1 != null)
            trustTier1.SetActive(false);

        if (iSeeText != null)
            iSeeText.gameObject.SetActive(false);

        if (proveYourselfText != null)
            proveYourselfText.gameObject.SetActive(false);
    }

    public void OnSnailButtonClicked()
    {
        if (trustTier1 != null)
            trustTier1.SetActive(true);

        if (iSeeText != null)
            iSeeText.gameObject.SetActive(true);

        if (proveYourselfText != null)
            proveYourselfText.gameObject.SetActive(true); //Show when clicked
    }
}
