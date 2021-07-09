using UnityEngine;

public class Flashlight : Weapon
{
    [field: SerializeField] private Light[] Lights { get; set; }

    protected override void OnFirePressed()
    {
        foreach (var light in Lights)
        {
            light.enabled = !light.enabled;
        }
    }
}
