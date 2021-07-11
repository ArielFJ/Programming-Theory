using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseScreen;

    private void Start()
    {
        InputManager.Instance.onPause += PauseGame;
        InputManager.Instance.onUnpause += ResumeGame;
        FindObjectOfType<FadePanel>().PlayFadeOutAnimation();
    }

    public void PauseGame()
    {
        GameManager.Instance.PauseGame();
        _pauseScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        GameManager.Instance.ResumeGame();
        _pauseScreen.SetActive(false);
    }

    public void GoToMenu()
    {
        GameManager.Instance.LoadMenuScene();
    }
}
