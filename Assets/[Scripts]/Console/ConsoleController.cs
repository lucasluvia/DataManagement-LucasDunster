using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleController : MonoBehaviour
{
    public Canvas consoleCanvas;
    public Canvas playerCanvas;
    public Canvas winCanvas;
    public Canvas pauseCanvas;

    private int collectedPickups = 0;

    bool ConsoleIsOn = true;
    bool PauseIsOn = true;

    public Button submitButton;

    PlayerController playerController;

    public AudioSource SubmitSFX;
    public AudioSource WinSFX;

    void Start()
    {
        playerController = GameObject.Find("Jackie").GetComponent<PlayerController>();
        submitButton = GameObject.Find("SubmitButton").GetComponent<Button>();
        submitButton.gameObject.SetActive(false);
        winCanvas.enabled = false;
        ToggleConsole();
        TogglePause();
    }

    public void ToggleConsole()
    {
        if(ConsoleIsOn)
        {
            SetConsoleEnabled(false);
        }
        else
        {
            SetConsoleEnabled(true);
        }
    }

    public void TogglePause()
    {
        PauseIsOn = !PauseIsOn;
        pauseCanvas.enabled = PauseIsOn;
    }

    void SetConsoleEnabled(bool toggleTo)
    {
        consoleCanvas.enabled = toggleTo;
        consoleCanvas.GetComponent<GraphicRaycaster>().enabled = toggleTo;
        playerCanvas.GetComponent<GraphicRaycaster>().enabled = toggleTo;
        ConsoleIsOn = toggleTo;
    }

    public void IncrementPickups()
    {
        collectedPickups++;
        if(collectedPickups >= 10)
        {
            submitButton.gameObject.SetActive(true);
            SubmitSFX.Play();
        }
    }

    public void EndGame()
    {
        SetConsoleEnabled(false);
        playerCanvas.enabled = false;
        winCanvas.enabled = true;
        playerController.GameOver = true;
        WinSFX.Play();
    }

}
