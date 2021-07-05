using System;
using UnityEngine;

public class WeaponPickup : Pickup
{
    private void OnTriggerEnter(Collider other)
    {
        EnableCollectText("F", this);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                Collect(player);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        DisableCollectText();
    }

    protected override void Collect(Character character)
    {
        Player player = character as Player;
        Weapon weapon = GetComponent<Weapon>();
        player.AddWeapon(weapon);
        DisableCollectText();
        Destroy(this);
    }
}
