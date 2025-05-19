using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera vCam1;
    public CinemachineVirtualCamera vCam2;
    public float postBlendDelay = 0.5f; // buffer time after blend

    private bool switchTriggered = false;
    private bool switchCompleted = false;
    private float blendCompleteTime = -1f;

    private CinemachineBrain brain;

    void Start()
    {
        brain = Camera.main.GetComponent<CinemachineBrain>();
    }

    void Update()
    {
        if (!switchTriggered && Input.anyKeyDown)
        {
            switchTriggered = true;
            vCam1.Priority = 0;
            vCam2.Priority = 10;
        }

        if (switchTriggered && !switchCompleted)
        {
            // Wait until blend finishes
            if (!brain.IsBlending && blendCompleteTime < 0f)
            {
                blendCompleteTime = Time.time;
            }

            // Wait buffer time after blend
            if (blendCompleteTime > 0f && Time.time >= blendCompleteTime + postBlendDelay)
            {
                switchCompleted = true;
            }
        }
    }

    public bool HasSwitched()
    {
        return switchCompleted;
    }
}
