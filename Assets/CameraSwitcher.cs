using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera vCam1;
    public CinemachineVirtualCamera vCam2;
    public GameObject explodeButtonGroup;
    public GameObject anyToContinue; // <-- NEW
    public float postBlendDelay = 0.5f;

    private bool switchTriggered = false;
    private bool switchCompleted = false;
    private float blendCompleteTime = -1f;

    private CinemachineBrain brain;

    void Start()
    {
        brain = Camera.main.GetComponent<CinemachineBrain>();

        if (explodeButtonGroup != null)
            explodeButtonGroup.SetActive(false);

        if (anyToContinue != null)
            anyToContinue.SetActive(true); // show by default
    }

    void Update()
    {
        if (!switchTriggered && Input.anyKeyDown)
        {
            switchTriggered = true;
            vCam1.Priority = 0;
            vCam2.Priority = 10;

            // Hide "anyToContinue" immediately after input
            if (anyToContinue != null)
                anyToContinue.SetActive(false);
        }

        if (switchTriggered && !switchCompleted)
        {
            if (!brain.IsBlending && blendCompleteTime < 0f)
            {
                blendCompleteTime = Time.time;
            }

            if (blendCompleteTime > 0f && Time.time >= blendCompleteTime + postBlendDelay)
            {
                switchCompleted = true;

                if (explodeButtonGroup != null)
                    explodeButtonGroup.SetActive(true);
            }
        }
    }

    public bool HasSwitched()
    {
        return switchCompleted;
    }
}
