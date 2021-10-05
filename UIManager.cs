using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public CanvasGroup screenElements;
    public CanvasGroup gameOverPanel;
    public CanvasGroup ninjaButtons;
    public CanvasGroup robotButton;
    private IEnumerator coroutine;
    private CharacterNumber characterNumber;

    private void Awake()
    {
        characterNumber = FindObjectOfType<CharacterNumber>();
    }

    private void Start()
    {
        ActivateNinjaButtons();
        ActivateRobotButton();
    }

    public void ChangeScreenElementsState(bool isVisible)
    {
        coroutine = ChangeScreenElementsStateCoroutine(isVisible);
        StartCoroutine(coroutine);
    }   

    private IEnumerator ChangeScreenElementsStateCoroutine(bool isVisible)
    {
        yield return new WaitForSecondsRealtime(0.5f);
        screenElements.alpha = isVisible ? 1 : 0;
    }

    public void ChangeGameOverPanelState(bool isVisible)
    {
        coroutine = ChangeGameOverPanelStateCoroutine(isVisible);
        StartCoroutine(coroutine);
    }

    private IEnumerator ChangeGameOverPanelStateCoroutine(bool isVisible)
    {        
        yield return new WaitForSecondsRealtime(0.5f);
        gameOverPanel.alpha = isVisible ? 1 : 0;
    }

    public void ActivateNinjaButtons()
    {
        ninjaButtons.alpha = characterNumber.GetUnlockedCharacterNumber() == 8 ? 1 : 0;
        ninjaButtons.blocksRaycasts = characterNumber.GetUnlockedCharacterNumber() == 8 ? true : false;
    }

    public void ActivateRobotButton()
    {
        robotButton.alpha = characterNumber.GetUnlockedCharacterNumber() == 9 ? 1 : 0;
        robotButton.blocksRaycasts = characterNumber.GetUnlockedCharacterNumber() == 9 ? true : false;
    }
}
