using UnityEngine;

public class Flashlight : Weapon
{
    [field: SerializeField] private Light Light { get; set; }

    protected override void OnFirePressed()
    {
        Light.enabled = !Light.enabled;
    }
}
