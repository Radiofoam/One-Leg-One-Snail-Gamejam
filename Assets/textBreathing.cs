using UnityEngine;

public class textBreathing : MonoBehaviour
{
    public float speed = 2f;      // Speed of breathing
    public float intensity = 0.05f; // Size change amount

    private Vector3 originalScale;

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
