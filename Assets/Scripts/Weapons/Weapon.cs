using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Player _player;

    public bool isCollected;
    public bool hasReloadTime;
    public float reloadTime;

    public bool hasFiringTime;
    public float firingTime;

    public bool useAmmo;
    public int maxAmmo;
    public int currentAmmo;

    [field: SerializeField] public Vector3 PositionOffset { get; private set; }
    [field: SerializeField] public Vector3 RotationOffset { get; private set; }

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        if (hasFiringTime)
        {
            InputManager.Instance.onFireDown += OnFire;
        }
        else
        {
            InputManager.Instance.onFire += OnFire;
        }
    }

    private void OnFire()
    {
        if (isCollected && _player.ActiveWeapon == this)
        {
            OnFirePressed();
        }
    }

    protected virtual void OnFirePressed()
    {

    }
}
