using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;



    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Audio Clips")]
    [SerializeField] public AudioClip backgroundMusic;
    [SerializeField] public AudioClip coinSound;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip winSound;
    [SerializeField] public AudioClip buttonSound;
    [SerializeField] public AudioClip jumpSound;

    void Awake()
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

    void Start()
    {
        PlayMusic();
    }

    // VOLUME 

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }


    // MUSIC 

    public void PlayMusic()
    {
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    //  SFX

    public void PlayCoin()
    {
        sfxSource.PlayOneShot(coinSound);
    }

    public void PlayJump()
    {
        sfxSource.PlayOneShot(jumpSound);
    }

    public void PlayDeath()
    {
        sfxSource.PlayOneShot(deathSound);
    }

    public void PlayWin()
    {
        sfxSource.PlayOneShot(winSound);
    }

    public void PlayButton()
    {
        sfxSource.PlayOneShot(buttonSound);
    }
}