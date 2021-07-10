using System;
using UnityEngine;

public class WeaponPickup : Pickup
{
    private Player _player;

    protected override void Start()
    {
        base.Start();
        InputManager.Instance.onCollect += OnCollect;
    }

    private void OnTriggerEnter(Collider other)
    {
        EnableCollectText("F", this);
        _player = other.GetComponent<Player>();
    }

    private void OnTriggerExit(Collider other)
    {
        _player = null;
        DisableCollectText();
    }

    void OnCollect()
    {
        if (_player != null)
        {
            Collect(_player);
        }
    }

    protected override void Collect(Character character)
    {
        base.Collect(character);
        Player player = character as Player;
        Weapon weapon = GetComponent<Weapon>();
        player.AddWeapon(weapon);
        DisableCollectText();
        Destroy(this);
    }
}
