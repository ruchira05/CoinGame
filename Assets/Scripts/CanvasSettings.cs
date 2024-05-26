//Pause Scene Canvas Settings
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasSettings : MonoBehaviour
{
    //restart the game
     public void Restart(){
        SceneManager.LoadScene(1);
    }

    //Resume the game
    public void Resume(){
        SceneManager.UnloadSceneAsync(2);
    }

    //Quit the Game
    public void QuitGame(){
        Application.Quit();
    }
}
