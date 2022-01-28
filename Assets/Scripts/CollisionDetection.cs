using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    SpawnGrounds spawnGrounds;
    // Start is called before the first frame update
    void Start()
    {
        spawnGrounds = FindObjectOfType<SpawnGrounds>();
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision happend");
        spawnGrounds.tetrisList.Dequeue();
    }
}
