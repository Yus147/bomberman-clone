using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] players;

    public GameObject[] enemies;


    // bool gameEnded = false;

    public float restartDelay = 1f; 

    public void LevelCompleted() 
    {
        Debug.Log("Level Completed");
    }

    public void CheckEnemysCount() 
    {
        int aliveCount = 0;

        foreach (GameObject enemy in enemies)
        {
            if(enemy.activeSelf)
            {
                aliveCount++;
            }
        }

        if (aliveCount == 0)
        {
            Debug.Log("Level Completed");
            Invoke(nameof(NextLevel), 3f);
        }
    }

    public void CheckPlayerState()
    {
        int aliveCount = 0;

        foreach (GameObject player in players)
        {
            if(player.activeSelf)
            {
                aliveCount++;
            }
        }

        if(aliveCount <= 1)
        {
            Debug.Log("Game Over");
            Invoke(nameof(Restart), 3f);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
