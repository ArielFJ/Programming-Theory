using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Player _player;
    
    public bool isCollected;

    [field: SerializeField] public Vector3 PositionOffset { get; private set; }
    [field: SerializeField] public Vector3 RotationOffset { get; private set; }

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (_player.ActiveWeapon != this) return;

        if (isCollected && Input.GetButtonDown("Fire1"))
        {
            OnFirePressed();
        }
    }

    protected virtual void OnFirePressed()
    {

    }
}
