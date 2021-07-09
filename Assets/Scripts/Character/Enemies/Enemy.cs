using UnityEngine;

public class Enemy : Character
{
    [SerializeField] protected float _moveSpeed;
    [field: SerializeField] public float DamageAmount { get; private set; }
}
