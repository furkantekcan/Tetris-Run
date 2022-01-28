using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGrounds : MonoBehaviour
{
    public GameObject groundFlat;
    public GameObject ground1;
    public GameObject ground2;
    public GameObject ground3;
    public int maxGroundCount = 10;
    public int totalGroundCount = 0;
    
    public Queue<GameObject> cloneList = new Queue<GameObject>();
    public Queue<GameObject> tetrisList = new Queue<GameObject>();

    private List<GameObject> groundList = new List<GameObject>();

    Vector3 spawnPoint;
    GameObject temp;

    // Start is called before the first frame update
    void Start()
    {
        groundList.Add(groundFlat);
        groundList.Add(ground1);
        groundList.Add(ground2);
        groundList.Add(ground3);
        
        GroundSpawner();
        
        for (int i = 0; i < 5; i++)
        {
            RandomGroundSpawner();
        }
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    public void GroundSpawner()
    {
        temp = Instantiate(groundList[0], spawnPoint, Quaternion.identity);
        cloneList.Enqueue(temp);
        spawnPoint = temp.transform.GetChild(0).transform.position;
        totalGroundCount += 1;
    }

    public void RandomGroundSpawner()
    {
        temp = Instantiate(groundList[Random.Range(1,4)], spawnPoint, Quaternion.identity);
        cloneList.Enqueue(temp);
        tetrisList.Enqueue(temp);
        spawnPoint = temp.transform.GetChild(0).transform.position;
        totalGroundCount += 1;
    }

}
