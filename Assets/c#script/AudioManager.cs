using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] AudioSource  musicSource;
    [SerializeField] AudioSource sfxSource;


    [Header("Sound Effects")]
    public AudioClip jumpSFX;
    public AudioClip dashSFX;
    public AudioClip coinSFX;
    public AudioClip gameOverSFX;


}
