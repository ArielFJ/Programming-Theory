using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class Pickup : MonoBehaviour
{
    [SerializeField] protected Text collectText;
    protected Collider theCollider;

    [field: SerializeField] public string Name { get; set; }

    private void Start()
    {
        theCollider = GetComponent<Collider>();
        theCollider.isTrigger = true;
    }

    protected virtual void Collect(Character character)
    {

    }

    protected void EnableCollectText(string axisName, Pickup pickup)
    {
        collectText.text = TextsStorage.GetCollectText(axisName, pickup);
        collectText.gameObject.SetActive(true);
    }

    protected void DisableCollectText()
    {
        collectText.gameObject.SetActive(false);
    }
}
