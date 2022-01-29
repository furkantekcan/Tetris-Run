using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GamePlay : MonoBehaviour
{
    public GameObject player;
    public float dropSpeed = 20;

    private Vector2 firstPressPos;
    private Vector2 secondPressPos;
    private float currentSwipe;
    private float rotation = 0;
    private GameObject target;
    private Transform tetrisObj;

    SpawnGrounds spawnGrounds;

    private void Awake()
    {
        Time.timeScale = 1;
    }
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


            if (-100 <= currentSwipe && currentSwipe <= 100 && rb.velocity.y == 0 && !DOTween.IsTweening(obj))
            {
                Debug.Log(obj.transform.eulerAngles);          
                obj.DORotate(new Vector3(90, 0, 0), 0.3f, RotateMode.WorldAxisAdd);
            }
        }
    }

    public void OnPlayerPassed()
    {
        var rb = tetrisObj.GetComponent<Rigidbody>(); 
        rb.velocity = -transform.up * dropSpeed;
    }

    
}
