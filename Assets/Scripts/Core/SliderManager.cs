using UnityEngine;
using UnityEngine.UI;
public class SliderManager : MonoBehaviour
{
    [SerializeField] private Slider BGMslider;
    [SerializeField] private Slider SFXslider;

    private void Start()
    {
        LoadVolume();

        BGMslider.onValueChanged.AddListener(SetBGMvolume);
        SFXslider.onValueChanged.AddListener(SetSFXvolume);
    }

    public void SetBGMvolume(float value)
    {
        PlayerPrefs.SetFloat("BGMVolume", BGMslider.value);
        AudioManager.Instance.SetBGMVolume(BGMslider.value);    
    }

    public void SetSFXvolume(float value)
    {
        PlayerPrefs.SetFloat("SFXVolume", SFXslider.value);
        AudioManager.Instance.SetSFXVolume(SFXslider.value);    
    }


    public void LoadVolume()
    {
        BGMslider.value = PlayerPrefs.GetFloat("BGMVolume", 1f);
        SFXslider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);

        AudioManager.Instance.SetBGMVolume(BGMslider.value);
        AudioManager.Instance.SetSFXVolume(SFXslider.value);
    }
}
