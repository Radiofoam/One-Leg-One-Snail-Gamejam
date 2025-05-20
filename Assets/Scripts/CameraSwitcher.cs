using UnityEngine;
using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro; // Required for TextMeshProUGUI

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera vCam1;
    public CinemachineVirtualCamera vCam2;
    public GameObject explodeButtonGroup;
    public GameObject anyToContinue;
    public TextMeshProUGUI letMeInText; // <-- NEW
    public float postBlendDelay = 0.5f;

    private bool switchTriggered = false;
    private bool switchCompleted = false;

    private CinemachineBrain brain;
    private readonly string[] transitionSFX = { "Burn", "Ambulance" };
    private List<AudioSource> loopingSources = new List<AudioSource>();

    void Start()
    {
        brain = Camera.main.GetComponent<CinemachineBrain>();

        // Play and loop SFX at Start
        foreach (string sfxName in transitionSFX)
        {
            Sound s = AudioManager.instance.GetSFX(sfxName);
            if (s != null && s.clip != null)
            {
                GameObject tempGO = new GameObject($"Looping_{sfxName}");
                DontDestroyOnLoad(tempGO);

                AudioSource tempSource = tempGO.AddComponent<AudioSource>();
                tempSource.clip = s.clip;
                tempSource.loop = true;
                tempSource.volume = 0.1f;
                tempSource.pitch = Mathf.Pow(1.059463f, UnityEngine.Random.Range(-3, 4));
                tempSource.Play();

                loopingSources.Add(tempSource);
            }
            else
            {
                Debug.LogWarning($"SFX not found or has no clip: {sfxName}");
            }
        }

        if (explodeButtonGroup != null)
            explodeButtonGroup.SetActive(false);

        if (anyToContinue != null)
            anyToContinue.SetActive(true);

        if (letMeInText != null)
            letMeInText.gameObject.SetActive(false); // <-- Hide LET ME IN initially
    }

    void Update()
    {
        if (!switchTriggered && Input.anyKeyDown)
        {
            switchTriggered = true;
            if (anyToContinue != null)
                anyToContinue.SetActive(false);

            StartCoroutine(HandleCameraSwitch());
        }
    }

    private IEnumerator HandleCameraSwitch()
    {
        // Play Knock SFX
        AudioManager.instance.PlaySFX("Knock", 1f, 1.6f);
        yield return new WaitForSeconds(1f); // Wait 1 second after Knock

        if (letMeInText != null)
            letMeInText.gameObject.SetActive(true); // <-- Show LET ME IN

        // Switch camera
        vCam1.Priority = 0;
        vCam2.Priority = 10;

        yield return new WaitForSeconds(2.5f); // Wait before showing buttons

        if (letMeInText != null)
            letMeInText.gameObject.SetActive(false); // <-- Hide LET ME IN again

        if (explodeButtonGroup != null)
            explodeButtonGroup.SetActive(true);

        switchCompleted = true;
    }

    public bool HasSwitched()
    {
        return switchCompleted;
    }
}
