using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum DestinationScene
{
    MENU,
    GAME,
    INSTRUCTIONS
}

public class UIButtonBehaviour : MonoBehaviour
{
    public DestinationScene destinationScene;

    public void MoveScene()
    {
        switch (destinationScene)
        {
            case DestinationScene.MENU:
                SceneManager.LoadScene("MainMenu");
                break;
            case DestinationScene.GAME:
                SceneManager.LoadScene("Game");
                break;
            case DestinationScene.INSTRUCTIONS:
                SceneManager.LoadScene("Instructions");
                break;
        }
    }
}
