// Main Menu Script
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Play the game
    public void PlayGame(){
        SceneManager.LoadSceneAsync(1);
    }

    //Quit the Game
    public void QuitGame(){
        Application.Quit();
    }
}
