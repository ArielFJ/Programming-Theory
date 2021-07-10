using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collidable : MonoBehaviour
{
    public bool shouldDestroyAfterActivation;
    public List<GameObject> expectedObjects;

    public UnityEvent<Collision> onCollide;
    public UnityEvent<Collider> onTriggering;


    private void OnCollisionEnter(Collision other)
    {
        if (expectedObjects == null || expectedObjects.Count == 0)
        {
            onCollide?.Invoke(other);
        }
        else
        {
            if (expectedObjects.Contains(other.gameObject))
            {
                onCollide?.Invoke(other);
            }
        }
        
        if (shouldDestroyAfterActivation) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (expectedObjects == null || expectedObjects.Count == 0)
        {
            onTriggering?.Invoke(other);
        }
        else
        {
            if (expectedObjects.Contains(other.gameObject))
            {
                onTriggering?.Invoke(other);
            }
        }

        if (shouldDestroyAfterActivation) gameObject.SetActive(false);
    }
}
