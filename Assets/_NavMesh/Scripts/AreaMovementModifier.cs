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
        //Unity Engine.AI is required for Navmesh
        // SamplePathPosition is a function that returns 
        NavMeshHit hit; 
        _agent.SamplePathPosition(-1, 0.0f, out hit); //grab the type of floor we are on.

        // Grassmask = 1 bitshift left until 'TallGrass' is found? Binary wise it shifts the 1 to the left 000000001< 000000010
        // User 4 is 16,        64 32 16 8  4  2  1 
        //                      0  0  1  0  0  0  0
        int GrassMask = 1 << NavMesh.GetAreaFromName("Tall Grass"); // User 4 is 16, 64 32 16 8  4  2   1 0  0  1  0  0  0   0
        int filtered = hit.mask & GrassMask; // Hit Mask is the Navmesh check, GrassMask is our check, both need to be true to trigger the mask
        //hitmask =   0000010000
        //GrassMask=  0000010000 This would be true, meaning we are touching grass.

        //Using binary (see picture on phone) 0 means we didnt hit the grass
        // 16 means we hit the grass.

        // the '10' that is next to Tall Grass in the inspector, is trhe 'weight value' e.g it takes 10 time longer/ harder to go through grass
        //So in theory the Navmesh will avoid this terrain unless its 10x shorter to go through, or has no other pathing choices.

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
