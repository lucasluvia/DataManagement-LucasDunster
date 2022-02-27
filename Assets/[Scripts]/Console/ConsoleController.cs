using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleController : MonoBehaviour
{
    public Canvas consoleCanvas;
    public Canvas playerCanvas;

    bool isOn = true;

    void Start()
    {
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

}
