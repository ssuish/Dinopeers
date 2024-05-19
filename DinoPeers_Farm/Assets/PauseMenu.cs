using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject darkPanel;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        darkPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        darkPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
