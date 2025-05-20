using UnityEngine;

public class noButton : MonoBehaviour
{
    public GameObject therapyButtonGroup;
    public GameObject explodeButtonGroup;

    void Awake()
    {
        if (therapyButtonGroup != null)
        {
            therapyButtonGroup.SetActive(false);
        }
    }

    public void OnNoPressed()
    {
        if (therapyButtonGroup != null)
        {
            therapyButtonGroup.SetActive(true);
        }

        if (explodeButtonGroup != null)
        {
            explodeButtonGroup.SetActive(false);
        }
    }
}
