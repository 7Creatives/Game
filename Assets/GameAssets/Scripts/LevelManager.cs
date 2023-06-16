using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject PauseScreen;
    public bool isGamePaused;
    public bool isSuccess;

    public GameObject winscreen;
    public GameObject GameOverscreen;

    public string[] sceneToload;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            PauseGame();
            CursorMode();
        }

        if(Win())
        {
            GameComlete(true);
            //GameManager.Instance.Loader_.Menu = winscreen;
        }
        else if(GameOver())
        {
            GameComlete(false);
            //GameManager.Instance.Loader_.Menu = GameOverscreen;
        }
    }

    public void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0;
        PauseScreen.SetActive(true);
        GameManager.Instance.CountDowntimer_.pauseTimer();
        GameManager.Instance.MovementHandler_.enabled =false;
        GameManager.Instance.PlayerCombat_.enabled = false;

    }

    public void ContinueGame()
    {
        isGamePaused = false;
        Time.timeScale = 1;
        PauseScreen.SetActive(false);
        GameManager.Instance.CountDowntimer_.resumeTimer();
        GameManager.Instance.MovementHandler_.enabled =true;
        GameManager.Instance.MovementHandler_.enabled =true;
    }

    public void returnToMainMenu()
    {
        Time.timeScale = 1;
        if(Win())
       {
            winscreen.SetActive(false);
       }
       else if(GameOver())
       {
            GameOverscreen.SetActive(false);
       }

       GameManager.Instance.Loader_.sceneToLoad = sceneToload[1].ToString();
       GameManager.Instance.Loader_.Load();
    }

    public void retry()
    {
        GameOverscreen.SetActive(false);
        GameManager.Instance.Loader_.sceneToLoad = sceneToload[2];
        GameManager.Instance.Loader_.Load();
    }

    public void NextLevel()
    {
        if(sceneToload[3] == null)
        {
            return;
        }
        else
        {
            winscreen.SetActive(false);
            GameManager.Instance.Loader_.sceneToLoad = sceneToload[2];
            GameManager.Instance.Loader_.Load();
        }
       
    }

    public void Sound()
    {

    }

    public void CursorMode()
    {
        if(isGamePaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public bool GameOver()
    {
        if(GameManager.Instance.playerHealth_.currentHealth <= 0 || GameManager.Instance.CountDowntimer_.timeValue <= 0)
        {
            GameOverscreen.SetActive(true);
            GameManager.Instance.MovementHandler_.enabled =false;
            GameManager.Instance.PlayerCombat_.enabled = false;
            GameManager.Instance.CountDowntimer_.pauseTimer();
            return true;
        }

      return false;
    }

    public bool Win()
    {
        if(GameManager.Instance.EnemyCount_.DeadEnemyCount >= GameManager.Instance.EnemyCount_.GetTotalEnemies() && 
            GameManager.Instance.CollageCount_.counter >= GameManager.Instance.CollageCount_.GetTotalCollages())
        {
            GameManager.Instance.MovementHandler_.enabled =false;
            GameManager.Instance.PlayerCombat_.enabled = false;
            GameManager.Instance.CountDowntimer_.pauseTimer();
            winscreen.SetActive(true);
            return true;
        }

        return false;
    }

    public void GameComlete(bool succes)
    {
       if(succes)
       {
            isSuccess = true;
       }
       else
       {
            isSuccess = false;
       }
       
    }
}
