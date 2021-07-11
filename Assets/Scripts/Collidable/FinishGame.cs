using System;
using System.Collections;
using System.Threading.Tasks;
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
        //yield return new WaitForSeconds(_secondsToFinish);
        //yield return new WaitForSeconds(1.5f);
        //await Task.Delay(1500);
        StartCoroutine(WaitSeconds(1.5f, () =>
        {
            //_fadePanel.PlayFadeInAnimation();
            Debug.Log("Hola");
            GameManager.Instance.LoadMenuScene();
        }));
        //StartCoroutine(GoToMenuAfterSeconds());
    }

    IEnumerator WaitSeconds(float seconds, Action afterSeconds)
    {
        yield return new WaitForSeconds(seconds);
        afterSeconds();
    }
}
