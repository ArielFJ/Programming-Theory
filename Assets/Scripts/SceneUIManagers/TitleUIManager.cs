using System;
using System.Collections;
using UnityEngine;

public class TitleUIManager : MonoBehaviour
{
    private FadePanel _fadePanel;

    private void Start()
    {
        _fadePanel = FindObjectOfType<FadePanel>();
        _fadePanel.PlayFadeOutAnimation();
    }

    public void StartGame()
    {
        StartCoroutine(StartGameSequence());
    }

    IEnumerator StartGameSequence()
    {
        _fadePanel.PlayFadeInAnimation();
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance.LoadGameScene();
    }

    public void ExitGame()
    {
        GameManager.Instance.ExitGame();
    }
}
