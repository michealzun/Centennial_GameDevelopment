using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderController : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public  void SetSliderValue(float value)
    {
        PlayerPrefs.SetFloat("MusicVolume", value);
    }
}
