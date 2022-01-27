using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    private static int i = 0;
    SpawnGrounds spawnGrounds;

    // Start is called before the first frame update
    void Start()
    {
        spawnGrounds = FindObjectOfType<SpawnGrounds>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //}

    private void OnTriggerExit(Collider other)
    {
        if (i < spawnGrounds.groundCount)
        {
            spawnGrounds.RandomGroundSpawner();
            Destroy(gameObject, 2);
            spawnGrounds.cloneList.Dequeue();
             i+= 1;
        }
        
    }
}
