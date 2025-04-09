using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        // Set initial volume and slider value
        float savedVolume = PlayerPrefs.GetFloat("GameVolume", 1f);
        AudioListener.volume = savedVolume;
        volumeSlider.value = savedVolume;

        // Add listener
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("GameVolume", volume); // Save volume preference
    }
}
