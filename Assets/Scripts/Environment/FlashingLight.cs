using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class FlashingLight : MonoBehaviour
{
    private Light _light;
    private float _timer;
    private float _timeToTurnOn;
    private float _timeToTurnOff;
    private Coroutine _lastCoroutine;
    private float _defaultIntensity;

    [SerializeField] private bool _isEffectActive;
    [SerializeField] private float _maxTimeTurnedOff = 1.0f;
    [SerializeField] private float _maxTimeTurnedOn = .3f;

    // Start is called before the first frame update
    void Start()
    {
        _light = GetComponent<Light>();
        _defaultIntensity = _light.intensity;
        
        if (_isEffectActive) EnableEffect();
    }
    
    IEnumerator StartLightEffect()
    {
        ToggleLight(false);
        while (_isEffectActive)
        {
            if (!_light.enabled && _timer >= _timeToTurnOn)
            {
                ToggleLight(true);
            }

            if (_light.enabled && _timer >= _timeToTurnOff)
            {
                ToggleLight(false);
            }

            _timer += Time.deltaTime;
            yield return null;
        }
    }

    public void EnableEffect()
    {
        _lastCoroutine = StartCoroutine(StartLightEffect());
    }

    public void TurnOnLightsAfterSeconds(float turnOnLightsDelay)
    {
        _isEffectActive = false;
        
        StartCoroutine(TurnOnLights(turnOnLightsDelay));
        //if (_lastCoroutine != null) StopCoroutine(_lastCoroutine);
    }

    IEnumerator TurnOnLights(float delay)
    {
        yield return new WaitForSeconds(delay);
        _light.enabled = true;
    }

    public void DisableLight()
    {
        StopAllCoroutines();
        _light.enabled = false;
        _isEffectActive = false;
    }

    private void ToggleLight(bool isEnabled)
    {
        _timeToTurnOn = Random.Range(0f, _maxTimeTurnedOff);
        _timeToTurnOff = Random.Range(0f, _maxTimeTurnedOn);
        _light.enabled = isEnabled;
        _timer = 0;
    }
}
