using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AreaMovementModifier : MonoBehaviour
{
    [SerializeField] float _speed = 10f;
    [SerializeField] float _grassSpeed = 1f;
     NavMeshAgent _agent;

    private void Start()
    {

        _agent = GetComponent<NavMeshAgent>();


    }

    private void Update()
    {
        NavMeshHit hit;
        _agent.SamplePathPosition(-1, 0.0f, out hit);

        int GrassMask = 1 << NavMesh.GetAreaFromName("Tall Grass");
        int filtered = hit.mask & GrassMask;
        //Using binary (see picture on phone) 0 means we didnt hit the grass
        // 16 means we hit the grass.

        if (filtered == 0)
        {

            _agent.speed = _speed;
        }
        else
        {
            _agent.speed = _grassSpeed;
        }
        


        Debug.Log(hit.mask);
    }




}
