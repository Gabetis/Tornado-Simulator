using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    [SerializeField] private AudioSource SFXSource;
    [SerializeField] private AudioSource BGMSource;
    [SerializeField] private AudioClip[] SFXClip = new AudioClip[0];

    private void OnEnable()
    {
        GameEvent.OnSoundRequest += HanldeSFXSound;
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void HanldeSFXSound(SoundEvent sound)
    {
        switch(sound)
        {
            case SoundEvent.Sell: SFXSource.PlayOneShot(SFXClip[0]); break;
            case SoundEvent.Suction: SFXSource.PlayOneShot(SFXClip[1]); break;
        }
    }

    public float SetSFXVolume(float value)
    {
        SFXSource.volume = value;
        return value;
    }

    public float SetBGMVolume(float value)
    {
        BGMSource.volume = value;
        return value;
    }

    private void OnDisable()
    {
        GameEvent.OnSoundRequest -= HanldeSFXSound;
    }
}
