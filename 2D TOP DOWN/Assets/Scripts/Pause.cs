using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseMenu;
    private Score ScoreManager;
    public GameObject health;
    public GameObject score_text;
    public GameObject AmmoText;
    public GameObject crosshair;
    
    private void Start()
    {
        GamePaused = false;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        
        ScoreManager = FindObjectOfType<Score>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
                Cursor.visible = true;
            }
            else
            {
                StopGame();
                Cursor.visible = false;
            }
        }
    }

    private void Resume()
    {
        pauseMenu.SetActive(false);
        health.SetActive(true);
        crosshair.SetActive(true);
        score_text.SetActive(true);
        Time.timeScale = 1f;
        GamePaused = false;
        AmmoText.SetActive(true);
        
        
    }

    private void StopGame()
    {
        pauseMenu.SetActive(true);
        health.SetActive(false);
        score_text.SetActive(false);
        Time.timeScale = 0f;
        GamePaused = true;
        AmmoText.SetActive(false);
        crosshair.SetActive(false);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Loading menu...");
        SceneManager.LoadScene("Menu");
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        health.SetActive(true);
        crosshair.SetActive(true);
        score_text.SetActive(true);
        Time.timeScale = 1f;
        GamePaused = false;
        AmmoText.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game....");
    }

    public void RestartGame()
    {
        pauseMenu.SetActive(false);
        Debug.Log("Game restrating...");
        GamePaused = false;
        Time.timeScale = 1f;
        StartCoroutine(Reload());
    }

    public void NextLevel()
    {
        Debug.Log("Next Level loading...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
        ScoreManager.ScoreNum = 0;
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(0.2f);
        Resources.UnloadUnusedAssets();
        SceneManager.LoadScene("1");
        
        ScoreManager.ScoreNum = 0;
    }
}