using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("---------- Audio Clip ----------")]
    public AudioClip backgroundMusic;
    public AudioClip Prompt;
    public AudioClip PlaceTower;
    public AudioClip Use;
    public AudioClip EnemyHit;
    public AudioClip Denied;
    public AudioClip EnemyDeath;
    public AudioClip Confirm;
    public AudioClip Decline;
    public AudioClip Purchase;
    public AudioClip CrossbowShot;
    public AudioClip SanitizerDispense;
    public AudioClip SodaLaunch;
    public AudioClip BandaidShot;
    public AudioClip SodaExplosion;

    
    
    private void Start()
    {
        
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }

    public float GetVolume()
    {
        return musicSource.volume;
    }
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
        
    
    
    public void changeVolume(float newVolume)
    {
        musicSource.volume = newVolume;
        sfxSource.volume = newVolume;
    }
}
