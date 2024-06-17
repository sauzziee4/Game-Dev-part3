using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    public AudioSource backgroundMusic;
    public AudioSource buttonPressSound;
    public AudioSource speedBoostSound;
    public AudioSource jumpBoostSound;
    public AudioSource immunitySound;
    public AudioSource bossSound;
    public AudioSource deathSound;
    public AudioSource footStepsSound;
    public AudioSource pickupActivationSound;

    public AudioClip buttonpressedSoundClip;


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
    private void Start()
    {
        if (buttonPressSound ==null)
        {
            buttonPressSound= gameObject.AddComponent<AudioSource>();
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
    public void SetBackgroundMusicVolume(float volume)
    {
        backgroundMusic.volume = Mathf.Clamp01(volume);  // Ensure volume is within range [0, 1]
    }

    // Play button press sound
    public void PlayButtonPressSound()
    {
        
            buttonPressSound.PlayOneShot(buttonpressedSoundClip);
        
    }
    public void SetButtonPressedVolume(float volume)
    {
        buttonPressSound.volume = Mathf.Clamp01(volume);  // Ensure volume is within range [0, 1]
    }

    // Play pickup activation sound
    public void PlayPickupActivationSound()
    {
        if (pickupActivationSound != null)
        {
            pickupActivationSound.PlayOneShot(pickupActivationSound.clip);
        }
    }
    public void SpeedBoostSound()
    {
      speedBoostSound.PlayOneShot(speedBoostSound.clip);
    }
    public void JumpBoostSound()
    { 
      jumpBoostSound.PlayOneShot(jumpBoostSound.clip);
    }
    public void ImmunitySound()
    {
        immunitySound.PlayOneShot(immunitySound.clip);
    }
    public void BossSound()
    {
        bossSound.PlayOneShot(pickupActivationSound.clip);
    }
    public void DeathSound()
    {
        deathSound.PlayOneShot(deathSound.clip);
    }
    public void FootStepsSound()
    {
        footStepsSound.PlayOneShot(footStepsSound.clip);
    }
   


}
