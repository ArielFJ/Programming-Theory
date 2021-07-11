using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUIManager : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.LoadGameScene();
    }

    public void ExitGame()
    {
        GameManager.Instance.ExitGame();
    }
}
