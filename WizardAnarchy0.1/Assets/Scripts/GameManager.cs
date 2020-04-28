using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float restartTimer;
    bool gameOver = false;
    public void GameOver()
    {
        if(gameOver == false)
        {
            gameOver = true;
            Debug.Log("Scene restarted");
            Invoke("RestartStage", restartTimer);
        }
    }

    private void RestartStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
