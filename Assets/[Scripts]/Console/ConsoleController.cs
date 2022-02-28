using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleController : MonoBehaviour
{
    public Canvas consoleCanvas;
    public Canvas playerCanvas;
    public Canvas winCanvas;

    private int collectedPickups = 0;

    bool isOn = true;

    public Button submitButton;

    PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("Jackie").GetComponent<PlayerController>();
        submitButton = GameObject.Find("SubmitButton").GetComponent<Button>();
        submitButton.enabled = false;
        winCanvas.enabled = false;
        ToggleConsole();
    }

    public void ToggleConsole()
    {
        if(isOn)
        {
            SetConsoleEnabled(false);
        }
        else
        {
            SetConsoleEnabled(true);
        }
    }

    void SetConsoleEnabled(bool toggleTo)
    {
        consoleCanvas.enabled = toggleTo;
        consoleCanvas.GetComponent<GraphicRaycaster>().enabled = toggleTo;
        playerCanvas.GetComponent<GraphicRaycaster>().enabled = toggleTo;
        isOn = toggleTo;
    }

    public void IncrementPickups()
    {
        collectedPickups++;
        if(collectedPickups >= 10)
        {
            submitButton.enabled = true;
        }
    }

    public void EndGame()
    {
        SetConsoleEnabled(false);
        playerCanvas.enabled = false;
        winCanvas.enabled = true;
        playerController.GameOver = true;
    }

}
