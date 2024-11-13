using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioMixer audioMixer;

    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<AudioManager>();
            }
            return instance;
        }

        private set{}
    }

    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject == Instance.gameObject)
        {
            DontDestroyOnLoad(gameObject); // dont destroy the original
        }
        else
        {
            Destroy(gameObject); // destroy as it is not the original to prevent duplicates in the scene
        }

    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public float GetMusicVolume()
    {
        audioMixer.GetFloat("MusicVolume", out float volume);
        return volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
