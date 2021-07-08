using UnityEngine;
using UnityEngine.Events;

public class Collidable : MonoBehaviour
{
    public UnityEvent<Collider> onCollide;

    private void OnTriggerEnter(Collider other)
    {
        onCollide?.Invoke(other);
    }
}
