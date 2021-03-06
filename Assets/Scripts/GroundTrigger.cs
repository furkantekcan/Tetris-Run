using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    SpawnGrounds spawnGrounds;

    // Start is called before the first frame update
    void Start()
    {
        spawnGrounds = FindObjectOfType<SpawnGrounds>();
    }


    private void OnTriggerExit(Collider other)
    {
        if (spawnGrounds.totalGroundCount < spawnGrounds.maxGroundCount)
        {
            spawnGrounds.RandomGroundSpawner();
            Destroy(gameObject, 2);
            spawnGrounds.cloneList.Dequeue();
        }
        else if (spawnGrounds.totalGroundCount == spawnGrounds.maxGroundCount)
        {
            Debug.LogWarning(gameObject.name);
        }
    }
}

