using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMove : MonoBehaviour {

    [SerializeField]
    GameObject _destination;

    public float agent_speed;
    public float agent_navigation;

    NavMeshAgent _navMeshAgent;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _destination = GameObject.FindWithTag("Destination");

        if (_navMeshAgent==null)
        {
            Debug.Log("The NavMeshAgent game component is not attached to " + gameObject.name);
        } else
        {
            SetDestination();
            _navMeshAgent.speed = agent_speed;
            _navMeshAgent.acceleration = agent_navigation;
        }
    }

    private void SetDestination()
    {
        if (_destination != null)
        {
            Vector3 targetVector = _destination.transform.position;
            _navMeshAgent.SetDestination(targetVector);
        }
    }

}
