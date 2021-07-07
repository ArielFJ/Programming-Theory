using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] private float _mouseSensivity = 5.0f;
    [SerializeField] private float _verticalLimit = 60;
    [SerializeField] private bool _invertY = true;

    private float xRotation;

    // Start is called before the first frame update
    void Start()
    {
        _mouseSensivity = transform.parent.GetComponent<PlayerController>().RotationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        RotateAroundX();
        //transform.Rotate(Vector3.right * -Time.deltaTime);
    }

    private void RotateAroundX()
    {
        var mouseY = InputManager.Instance.LookVector.y * _mouseSensivity * Time.deltaTime;
        xRotation += _invertY ? -mouseY : mouseY;
        xRotation = Mathf.Clamp(xRotation, -_verticalLimit, _verticalLimit);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
