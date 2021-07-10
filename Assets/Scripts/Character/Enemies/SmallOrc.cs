using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class SmallOrc : Enemy
{
    [SerializeField] public Transform _target;
    private NavMeshAgent _agent;
    private Animator _animator;

    public Vector3 agentDestination;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = gameObject.GetComponentInChildren<Animator>();
        _agent.speed = _moveSpeed;
        _agent.isStopped = true;
    }

    //void Update()
    //{
    //    if (Vector3.Distance(transform.position, agentDestination) <= _agent.stoppingDistance)
    //    {
    //        Disappear();
    //    }
    //}

    //private void Disappear()
    //{
    //    gameObject.SetActive(false);
    //    Debug.Log($"Disappear: {agentDestination}");
    //}

    public override void Move()
    {
        if (_target == null) return;
        agentDestination = _target.position;
        _agent.SetDestination(new Vector3(agentDestination.x, 0, agentDestination.z));
        Debug.Log($"Move: {Vector3.Distance(transform.position, agentDestination)}");
        _agent.isStopped = false;
        _animator.SetFloat("MoveSpeed", .8f);
    }

    public void SetTarget(Transform newTarget)
    {
        _target = newTarget;
        _agent.SetDestination(_target.position);
    }
}
