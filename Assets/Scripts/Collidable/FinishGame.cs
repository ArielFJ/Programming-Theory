using System;
using System.Collections;
using UnityEngine;

public class FinishGame : MonoBehaviour
{

    [SerializeField] private float _secondsToFinish = 5.0f;
    private FadePanel _fadePanel;

    private void Start()
    {
        _fadePanel = FindObjectOfType<FadePanel>();
    }

    public void StartFinishSequence()
    {
        StartCoroutine(WaitSeconds(_secondsToFinish, () =>
        {
            _fadePanel.PlayFadeInAnimation();
        }));

        StartCoroutine(WaitSeconds(1.5f, () =>
        {
            GameManager.Instance.LoadMenuScene();
        }));
    }

    IEnumerator WaitSeconds(float seconds, Action afterSeconds)
    {
        yield return new WaitForSeconds(seconds);
        afterSeconds();
    }
}
