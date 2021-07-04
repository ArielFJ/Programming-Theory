using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] private float _mouseSensivity = 5.0f;
    [SerializeField] private float _verticalLimit = 60;
    [SerializeField] private bool _invertY = true;

    private float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateAroundX();
        //transform.Rotate(Vector3.right * -Time.deltaTime);
    }

    private void RotateAroundX()
    {
        var mouseY = Input.GetAxis("Mouse Y") * _mouseSensivity * Time.deltaTime;
        xRotation += _invertY ? -mouseY : mouseY;
        xRotation = Mathf.Clamp(xRotation, -_verticalLimit, _verticalLimit);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
