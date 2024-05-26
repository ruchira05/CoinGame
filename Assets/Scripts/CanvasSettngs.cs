// This is for setup the volume For UI Canvas
using UnityEngine;
using UnityEngine. Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasSettngs : MonoBehaviour
{
    //Get audio mixers to adjust the volume
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    //Adjust the music valume
    public void setMusicVolume(){
        float volume = musicSlider. value;
        myMixer. SetFloat ("music" , volume);
    }
    //Adjust the SFX valume
    public void setSFXVolume(){
        float volume = sfxSlider. value;
        myMixer. SetFloat ("sfx" , volume);
    }
    // pause the game
    public void Pause(){
        SceneManager.LoadSceneAsync(2,LoadSceneMode.Additive);
    }
}
