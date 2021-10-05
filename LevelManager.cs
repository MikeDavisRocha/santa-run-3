using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private GameManager gameManager;
    private LevelNumber levelNumber;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        levelNumber = FindObjectOfType<LevelNumber>();
    }

    public void LoadPregameScene()
    {
        SceneManager.LoadSceneAsync("1 - Pregame");
        gameManager.StoptGame();
    }

    public void LoadCharacterSelection()
    {
        StartCoroutine("LoadCharacterSelectionCoroutine");
    }

    IEnumerator LoadCharacterSelectionCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadSceneAsync("2 - CharacterSelection");
    }

    public void LoadLevelSelectionSelection()
    {
        StartCoroutine("LoadLevelSelectionSelectionCoroutine");
    }

    IEnumerator LoadLevelSelectionSelectionCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadSceneAsync("3 - LevelSelection");
    }

    public void LoadGameScene()
    {
        StartCoroutine("LoadGameSceneCoroutine");
    }

    IEnumerator LoadGameSceneCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        int index = levelNumber.GetLevelNumber();
        SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
        gameManager.StartGame();
    }

    public void QuitMenu()
    {
        Application.Quit();
    }
}
