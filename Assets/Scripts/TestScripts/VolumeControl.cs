using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider buttonPressedSlider;
   
    // Start is called before the first frame update
    void Start()
    {
        //buttonPressedSlider.value = AudioManager.Instance.buttonPressSound.volume;
        //buttonPressedSlider.onValueChanged.AddListener(OnButtonPressedVolumeChanged);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnButtonPressedVolumeChanged(float volume)
    {
        AudioManager.Instance.SetButtonPressedVolume(volume);
        
    }
   
    
}
