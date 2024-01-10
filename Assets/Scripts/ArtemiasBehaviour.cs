using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ArtemiasBehaviour : MonoBehaviour
{

    public bool lightOn = false;
    public bool otherOnLight = false;
    public float speed;
    [SerializeField] float range;
    Vector2 ranges;
    NavMeshAgent agent;
    GameObject master;
    MasterPlayerController masterCode;
    ArtemiasBehaviour otherShrimp;
    Vector3 distance;
    Vector3 targetPos;
    Rigidbody rBody;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        rBody = GetComponent<Rigidbody>();
        if (FindFirstObjectByType<MasterPlayerController>() != null)
        {
            master = FindFirstObjectByType<MasterPlayerController>().gameObject;
            masterCode = master.GetComponent<MasterPlayerController>();
        }
       
        RandomDirection();
    }
    // Update is called once per frame
    void Update()
    {
        MoveToTargetPos();
    }
    void MoveToTargetPos()
    {
        if (master.activeInHierarchy == true)
        {
            if (lightOn == true)
            {
                agent.SetDestination(masterCode.crumb.position);
                transform.LookAt(masterCode.crumb.position);
            }else{SwimAround();}
        }else{SwimAround();}
    }
    void SwimAround()
    {
        agent.SetDestination(targetPos);
        distance = (targetPos - transform.position);
        if (distance.magnitude < 2)
        {
            RandomDirection();
        }
    }
    void RandomDirection()
    {
        targetPos = PoolManager.RandomPointGenerator(Vector3.back,range);
        transform.LookAt(targetPos);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("shrimp") || other.CompareTag("master"))
        {
            speed = speed * 2f;
            agent.speed = speed;
        }
        if (other.CompareTag("master"))
        {
            lightOn = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("shrimp") || other.CompareTag("master"))
        {
            speed = speed * 0.5f;
            agent.speed = speed;
        }
    }
}
