using System;
using UnityEngine;
using UnityEngine.Events;

public class Collidable : MonoBehaviour
{
    public UnityEvent<Collision> onCollide;
    public UnityEvent<Collider> onTriggering;

    private void OnCollisionEnter(Collision other)
    {
        onCollide?.Invoke(other);
    }

    private void OnTriggerEnter(Collider other)
    {
        onTriggering?.Invoke(other);
    }
}
