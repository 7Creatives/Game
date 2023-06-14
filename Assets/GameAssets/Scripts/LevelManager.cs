using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject PauseScreen;
    public bool isGamePaused;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
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
}
