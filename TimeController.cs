using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    private float currentTime;
    public Text textBox;
    public bool isRunning = false;

    private void Start()
    {
        textBox.text = currentTime.ToString();
    }    

    private void Update()
    {
        if (isRunning)
        {
            RunTime();
        }
    }

    public void StartTime()
    {
        isRunning = true;
    }

    public float GetCurrentTime()
    {
        return currentTime;
    } 

    public void RunTime()
    {
        currentTime += Time.deltaTime;
        ChangeTimeText();      
    }

    private void ChangeTimeText()
    {
        if (currentTime >= 0)
        {
            textBox.text = Mathf.Round(currentTime).ToString("0");
        }
    }

    public void StopTime()
    {
        isRunning = false;
        ResetTime();
    }

    public void ResetTime()
    {
        currentTime = 0f;
    }
}
