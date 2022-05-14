using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartNewGame()
    {
        Debug.Log("StartNewGame");
        SceneManager.LoadScene(1);
    }
    public void OpenSettings() 
    {
        Debug.Log("OpenSettings");
    }
    public void ExitGame() 
    {
        Debug.Log("ExitGame");
        Application.Quit();
    }
}
