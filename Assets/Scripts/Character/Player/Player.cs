using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Player : Character
{
    [SerializeField] private Transform weaponPlaceholder;

    // ENCAPSULATION
    [field: SerializeField] public List<Weapon> Weapons { get; private set; }
    [field: SerializeField] public Weapon ActiveWeapon { get; private set; }

    public void AddWeapon(Weapon weapon)
    {
        Weapons.Add(weapon);
        Transform weaponTransform = weapon.gameObject.transform;
        weaponTransform.parent = weaponPlaceholder;
        weaponTransform.localPosition = weapon.PositionOffset;
        weaponTransform.localRotation = Quaternion.Euler(weapon.RotationOffset);
        weapon.isCollected = true;
        
        if (Weapons.Count == 1)
        {
            ActiveWeapon = weapon;
        }
    }
}
