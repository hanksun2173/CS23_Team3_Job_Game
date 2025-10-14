using UnityEngine;

public class RestartOnWin : MonoBehaviour
{
    public void RestartGame()
    {
        Time.timeScale = 1f;
        GameHandler_PauseMenu.GameisPaused = false;
        playerHealth = 5;
        SceneManager.LoadScene("Menu");
        
    }
}
