using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class SmallOrc : Enemy
{
    [SerializeField] public Transform _target;
    private NavMeshAgent _agent;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = _moveSpeed;
        _agent.isStopped = true;
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    public override void Move()
    {
        if (_target == null) return;
        Debug.Log("Following");
        _agent.SetDestination(_target.position);
        Debug.Log(_agent.remainingDistance);
        _agent.isStopped = false;
    }

    public void SetTarget(Transform newTarget)
    {
        _target = newTarget;
        _agent.SetDestination(_target.position);
    }
}
