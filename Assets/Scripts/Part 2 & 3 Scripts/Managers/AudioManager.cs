using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    public AudioSource backgroundMusic;
    public AudioSource buttonPressSound;
    public AudioSource pickupActivationSound;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Play background music
    public void PlayBackgroundMusic()
    {
        if (backgroundMusic != null && !backgroundMusic.isPlaying)
        {
            backgroundMusic.Play();
        }
    }

    // Play button press sound
    public void PlayButtonPressSound()
    {
        if (buttonPressSound != null)
        {
            buttonPressSound.PlayOneShot(buttonPressSound.clip);
        }
    }

    // Play pickup activation sound
    public void PlayPickupActivationSound()
    {
        if (pickupActivationSound != null)
        {
            pickupActivationSound.PlayOneShot(pickupActivationSound.clip);
        }
    }
}
