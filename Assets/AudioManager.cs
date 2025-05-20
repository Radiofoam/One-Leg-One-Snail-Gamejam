using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //PlayMusic("Theme");
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);
        if (s == null)
        {
            Debug.LogWarning("Music sound not found: " + name);
            return;
        }

        musicSource.clip = s.clip;
        musicSource.Play();
    }
    public Sound GetSFX(string name)
    {
        return Array.Find(sfxSounds, x => x.name == name);
    }

    public void PlaySFX(string name, float pitch = 1f, float volume = 1f)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound not found: {name}");
            return;
        }

        // Create a temporary GameObject
        GameObject tempGO = new GameObject("TempAudio");
        AudioSource tempSource = tempGO.AddComponent<AudioSource>();

        tempSource.clip = s.clip;
        tempSource.volume = volume;
        tempSource.pitch = pitch;
        tempSource.Play();

        Destroy(tempGO, s.clip.length / pitch); // Cleanup after playback
    }



}
