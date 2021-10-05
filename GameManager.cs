using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPaused;
    public static bool isRunning;
    private IEnumerator coroutine;
    private SoundController soundController;

    private void Awake()
    {
        soundController = FindObjectOfType<SoundController>();
    }
    private void Start()
    {
        soundController.Play("GameplaySound");        
    }

    public void StartGame()
    {
        isRunning = true;
    }

    public void StoptGame()
    {
        isRunning = false;
    }

    public bool GetGameState()
    {
        return isRunning;
    }

    public void GameOver()
    {
        coroutine = GameOverCoroutine();
        StartCoroutine(coroutine);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
    }

    private IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 0;
        isPaused = true;
    }

    private void FixedUpdate()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}
