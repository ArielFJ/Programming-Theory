using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadePanel : MonoBehaviour
{
    private Animator _animator;
    private Image _image;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _image = GetComponent<Image>();
    }

    public void PlayFadeInAnimation()
    {
        StartCoroutine(FadeIn());
    }

    public void PlayFadeOutAnimation()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeIn()
    {
        _image.enabled = true;
        _animator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1.5f);
        _image.color = new Color(0, 0, 0, 1);
    }

    IEnumerator FadeOut()
    {
        _animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1.5f);
        _image.enabled = false;
    }

}
