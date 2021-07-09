using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, PlayerInputAction.IPlayerActions
{
    public static InputManager Instance { get; private set; }

    private PlayerInputAction playerInputAction;
    private InputAction movement;
    private InputAction jump;
    private InputAction look;
    private InputAction collect;
    private InputAction fire;
    private InputAction fireDown;
    private InputAction run;

    #region States

    public bool IsRunning { get; private set; }
    
    #endregion

    // These actions are performed when the button is pressed
    #region Actions

    public Action onJump;
    public Action onCollect;
    public Action onFire;
    public Action onFireDown;
    private bool isFirePressed;

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
        playerInputAction = new PlayerInputAction();
    }

    private void OnEnable()
    {
        movement = playerInputAction.Player.Movement;
        look = playerInputAction.Player.Look;
        jump = playerInputAction.Player.Jump;
        collect = playerInputAction.Player.Collect;
        fire = playerInputAction.Player.Fire;
        fireDown = playerInputAction.Player.FireDown;
        run = playerInputAction.Player.Run;

        movement.performed += OnMovement;
        movement.canceled += OnMovement;
        look.performed += OnLook;
        look.canceled += OnLook;
        fireDown.performed += OnFireDown;
        fireDown.canceled += OnFireDown;
        run.performed += OnRun;
        run.canceled += OnRun;

        jump.performed += OnJump;
        collect.performed += OnCollect;
        fire.performed += OnFire;

        movement.Enable();
        look.Enable();
        jump.Enable();
        collect.Enable();
        fire.Enable();
        fireDown.Enable();
        run.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        look.Disable();
        jump.Disable();
        collect.Disable();
        fire.Disable();
        fireDown.Disable();
        run.Disable();
    }

    private void Update()
    {
        // For OnFireDown event
        if (isFirePressed) onFireDown?.Invoke();
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
            isFirePressed = true;
        if (context.canceled)
            isFirePressed = false;
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
}
