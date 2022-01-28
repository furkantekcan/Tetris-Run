using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public GameObject player;
    public float dropSpeed = 20;

    private Vector2 firstPressPos;
    private Vector2 secondPressPos;
    private float currentSwipe;
    private GameObject target;
    private Transform tetrisObj;

    SpawnGrounds spawnGrounds;

    // Start is called before the first frame update
    void Start()
    {
        spawnGrounds = FindObjectOfType<SpawnGrounds>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnGrounds.tetrisList.Count == 0)
        {
            return;
        }
        target = spawnGrounds.tetrisList.Peek();
        tetrisObj = target.transform.GetChild(1);
        TetrisMovement(tetrisObj);    
    }


    void TetrisMovement(Transform obj)
    {
        var rb = obj.GetComponent<Rigidbody>();

        if (Input.GetMouseButtonDown(0))
        {
            firstPressPos = Input.mousePosition * 10;
        }
        if (Input.GetMouseButtonUp(0))
        {
            secondPressPos = Input.mousePosition * 10;
            currentSwipe = secondPressPos.y - firstPressPos.y;
            if (currentSwipe < -10)
            {
                Debug.Log(secondPressPos.y - firstPressPos.y);
                rb.velocity = -transform.up * dropSpeed;
                
            }


            if (-10 <= currentSwipe && currentSwipe <= 10 && rb.velocity.y == 0)
            {
                Debug.Log(currentSwipe);
                obj.RotateAround(tetrisObj.position, Vector3.right, 90f);                
            }
        }
    }

    public void OnPlayerPassed()
    {
        var rb = tetrisObj.GetComponent<Rigidbody>(); 
        rb.velocity = -transform.up * dropSpeed;
    }

    
}
