using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // This Controls the Pause Menu
    public SceneFader sceneFader;
    public string menuSceneName = "StartMenu";
    public string settingsSceneName = "SettingsMenu";

    public static bool GameIsPaused = false; // This toggles on/off the pause
    public GameObject pauseMenuUI, player;// The GameObject we want to effect

    int sceneIndex; // This is so we can use + or - the active scene we are in for loading

    private void Start()
    {
        if (GameIsPaused) //this unpauses if we are reloading the scene
        {
            Resume();
        }
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1f;
        // Sets the scene to be able to use it in the Index
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button9))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            Replay();
        }

    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
        GameIsPaused = false;
        player.SetActive(true);
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        player.SetActive(false);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        sceneFader.FadeTo(menuSceneName);
    }
    public void LoadSettingsMenu()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        sceneFader.FadeTo(settingsSceneName);
    }
    public void Replay()
    {
        Time.timeScale = 1f;
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }
}

