using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputManager :
    MonoBehaviour,
    PlayerInputAction.IPlayerActions,
    PlayerInputAction.IPauseMenuActions
{
    public static InputManager Instance { get; private set; }

    private PlayerInput _playerInput;

    private PlayerInputAction _playerInputAction;
    private InputAction _movement;
    private InputAction _jump;
    private InputAction _look;
    private InputAction _collect;
    private InputAction _fire;
    private InputAction _fireDown;
    private InputAction _run;
    private InputAction _pause;
    private InputAction _unpause;

    #region States

    public bool IsRunning { get; private set; }

    #endregion

    // These actions are performed when the button is pressed
    #region Actions

    public Action onJump;
    public Action onCollect;
    public Action onFire;
    public Action onFireDown;
    public Action onPause;
    public Action onUnpause;
    private bool _isFirePressed;

    #endregion

    // These have some kind of direction in Vector2
    #region Directions

    public Vector3 MovementVector { get; private set; }
    public Vector2 LookVector { get; private set; }

    #endregion

    #region Unity Events

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        _playerInputAction = new PlayerInputAction();
    }

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        _movement = _playerInputAction.Player.Movement;
        _look = _playerInputAction.Player.Look;
        _jump = _playerInputAction.Player.Jump;
        _collect = _playerInputAction.Player.Collect;
        _fire = _playerInputAction.Player.Fire;
        _fireDown = _playerInputAction.Player.FireDown;
        _run = _playerInputAction.Player.Run;
        _pause = _playerInputAction.Player.Pause;
        _unpause = _playerInputAction.PauseMenu.Unpause;

        _movement.performed += OnMovement;
        _movement.canceled += OnMovement;
        _look.performed += OnLook;
        _look.canceled += OnLook;
        _fireDown.performed += OnFireDown;
        _fireDown.canceled += OnFireDown;
        _run.performed += OnRun;
        _run.canceled += OnRun;

        _jump.performed += OnJump;
        _collect.performed += OnCollect;
        _fire.performed += OnFire;
        _pause.performed += OnPause;
        _unpause.performed += OnUnpause;

        _movement.Enable();
        _look.Enable();
        _jump.Enable();
        _collect.Enable();
        _fire.Enable();
        _fireDown.Enable();
        _run.Enable();
        _pause.Enable();
        //_unpause.Enable();
    }

    private void OnDisable()
    {
        _movement.Disable();
        _look.Disable();
        _jump.Disable();
        _collect.Disable();
        _fire.Disable();
        _fireDown.Disable();
        _run.Disable();
        _pause.Disable();
        _unpause.Disable();
    }

    private void Update()
    {
        // For OnFireDown event
        if (_isFirePressed) onFireDown?.Invoke();
    }

    #endregion

    #region Movement

    public void OnMovement(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            var value = context.ReadValue<Vector2>();
            MovementVector = new Vector3(value.x, 0, value.y);
        }

        if (context.canceled)
            MovementVector = Vector3.zero;
    }

    #endregion

    #region Jump

    public void OnJump(InputAction.CallbackContext context)
    {
        onJump?.Invoke();
    }

    #endregion

    #region Look

    public void OnLook(InputAction.CallbackContext context)
    {
        if (context.performed)
            LookVector = context.ReadValue<Vector2>();

        if (context.canceled)
            LookVector = Vector2.zero;
    }

    #endregion

    #region Collect

    public void OnCollect(InputAction.CallbackContext context)
    {
        onCollect?.Invoke();
    }

    #endregion

    #region Fire

    public void OnFire(InputAction.CallbackContext context)
    {
        onFire?.Invoke();
    }

    public void OnFireDown(InputAction.CallbackContext context)
    {
        if (context.performed)
            _isFirePressed = true;
        if (context.canceled)
            _isFirePressed = false;
    }

    #endregion

    #region Run

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.performed)
            IsRunning = true;
        if (context.canceled)
            IsRunning = false;
    }

    #endregion

    #region Pause

    public void OnPause(InputAction.CallbackContext context)
    {
        onPause?.Invoke();
        _playerInput.SwitchCurrentActionMap(nameof(PlayerInputAction.PauseMenu));
        _unpause.Enable();
        _pause.Disable();
    }

    #endregion

    #region Unpause

    public void OnUnpause(InputAction.CallbackContext context)
    {
        onUnpause?.Invoke();
        _playerInput.SwitchCurrentActionMap(nameof(PlayerInputAction.Player));
        _unpause.Disable();
        _pause.Enable();
    }

    #endregion
}
