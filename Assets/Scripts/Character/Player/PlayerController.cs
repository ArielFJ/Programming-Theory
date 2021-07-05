using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _rotationSpeed = 2.0f;
    private Vector3 _move;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
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
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * mouseX * _rotationSpeed);
    }
}
