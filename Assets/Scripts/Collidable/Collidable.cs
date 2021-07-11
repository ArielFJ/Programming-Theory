using System;
using System.Collections;
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

        if (shouldDestroyAfterActivation) StartCoroutine(DestroyObject());
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

        if (shouldDestroyAfterActivation) StartCoroutine(DestroyObject());
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }

}
