using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public GameObject player;
    public float dropSpeed = 20;

    private Vector2 firstPressPos;
    private Vector2 secondPressPos;
    private Vector2 currentSwipe;

    GameObject target;
    Transform tetrisObj;

    SpawnGrounds spawnGrounds;

    // Start is called before the first frame update
    void Start()
    {
        spawnGrounds = FindObjectOfType<SpawnGrounds>();
    }

    // Update is called once per frame
    void Update()
    {
        target = FindClosestObj(spawnGrounds.cloneList, player);
        tetrisObj = target.transform.Find("Tetris");

        if (tetrisObj != null)
        {
            TetrisMovement(tetrisObj);
        }        
    }

    GameObject FindClosestObj(List<GameObject> clones, GameObject player)
    {
        GameObject bestTarget = null;

        float closestDistanceSqr = Mathf.Infinity;

        Vector3 currentPosition = player.transform.position;

        foreach (GameObject potentialTarget in clones)
        {
            if (potentialTarget.name != "Ground Flat(Clone)")
            {
                Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;

                if (potentialTarget.transform.position.z > currentPosition.z)
                {
                    if (dSqrToTarget < closestDistanceSqr)
                    {
                        closestDistanceSqr = dSqrToTarget;
                        bestTarget = potentialTarget;
                    }
                }
            }          
        }

        return bestTarget;
    }

    void TetrisMovement(Transform obj)
    {
        var rb = obj.GetComponent<Rigidbody>();

        if (Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            //normalize the 2d vector
            currentSwipe.Normalize();

            //swipe down
            if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                rb.velocity = -transform.up * dropSpeed;
            }

            // just rotate

            if (currentSwipe.y == 0 && currentSwipe.x == 0 && currentSwipe.x == 0)
            {
                obj.RotateAround(tetrisObj.position, Vector3.right, 90f);                
            }
        }
    }

    
}
