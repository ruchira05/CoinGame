// This is Audio Manager Screipt to Manage Audios in the game
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Get references for Audio Clips and Sources
    [Header ("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioSource musicGame;

    [Header ("---------- Audio Clip ----------")]
    public AudioClip background;
    public AudioClip coin;
    public AudioClip jump;
    public AudioClip win;
    public AudioClip run;

    //For Start a background music
    private void Start() {
        musicSource.clip =background;
        musicSource.Play();
    }
    //For Start a SFX
    public void PlaySFX(AudioClip audioClip){
        sfxSource.PlayOneShot(audioClip);
    }

    //For Start a Game Music
    public void PlayMusic(AudioClip audioClip){
        musicGame.clip =audioClip;
        musicGame.Play();
    }

    //For Stop a Game Music
    public void StopMusic(){
        musicGame.Stop();
    }

}
