using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartOnWin : MonoBehaviour
{
    public void RestartGame()
    {
        Time.timeScale = 1f;
        GameHandler_PauseMenu.GameisPaused = false;
        SceneManager.LoadScene("Menu");
        
    }
}
