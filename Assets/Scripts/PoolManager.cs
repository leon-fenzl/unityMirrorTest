using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class PoolManager : MonoBehaviour
{
    public GameObject objPrefab;
    [SerializeField] int poolSize;
    [SerializeField] float spawnRange;
    Vector3 spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        SpawnShrimp();
    }
    void SpawnShrimp()
    {
        for (int index = 0; index < poolSize; index++)
        {
            SpawnPosition();
            Instantiate(objPrefab,spawnPos,Quaternion.identity);
        }
    }
    void SpawnPosition()
    {
        spawnPos = RandomPointGenerator(Vector3.back, spawnRange);
    }
    public static Vector3 RandomPointGenerator(Vector3 rayHitStartPos, float radius)
    {
        Vector3 areaDir = Random.insideUnitSphere * radius;
        areaDir += rayHitStartPos;
        NavMeshHit actualHit;
        Vector3 hitPos=Vector3.zero;
        if (NavMesh.SamplePosition(areaDir, out actualHit, radius,1))
        {
            hitPos = actualHit.position;
        }
        return hitPos;
    }
}
