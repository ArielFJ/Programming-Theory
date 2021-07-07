using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float _speed = 5.0f;
    private Vector3 _move;

    [field: SerializeField] public float RotationSpeed { get; private set; } = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _move = InputManager.Instance.MovementVector;
        if (_move.magnitude > 0.1f)
        {
            Move(_move);
        }
        MoveCamera();
    }

    public void Move(Vector3 targetPos)
    {
        // Transform the targetPos from local to world position
        // Because MovePosition works with world position
        var moveDir = transform.TransformDirection(targetPos);
        _rb.MovePosition(_rb.position + moveDir * (_speed * Time.deltaTime));
    }

    private void MoveCamera()
    {
        float mouseX = InputManager.Instance.LookVector.x;
        transform.Rotate(Vector3.up * mouseX * RotationSpeed * Time.deltaTime);
    }
}
