using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class Pickup : MonoBehaviour
{
    [SerializeField] protected Text collectText;
    protected Collider theCollider;

    [field: SerializeField] public string Name { get; set; }
    public UnityEvent onCollected;

    protected virtual void Start()
    {
        theCollider = GetComponent<Collider>();
        theCollider.isTrigger = true;
    }

    protected virtual void Collect(Character character)
    {
        onCollected?.Invoke();
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
