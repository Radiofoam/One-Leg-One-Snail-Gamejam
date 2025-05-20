using TMPro;
using UnityEngine;

public class textBreathing : MonoBehaviour
{
    public float speed = 2f;      // Speed of breathing
    public float intensity = 0.05f; // Size change amount
    public TextMeshProUGUI liarText; // Assign "LIAR" TextMeshPro in Inspector
    private Vector3 originalScale;
    void OnEnable()
    {
        // This runs when the object becomes active
        if (liarText != null)
            liarText.gameObject.SetActive(false); // Hide LIAR each time this script is re-enabled
    }

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        float scaleOffset = Mathf.Sin(Time.time * speed) * intensity;
        transform.localScale = originalScale + Vector3.one * scaleOffset;
    }
}
