using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }

    //Update is called once per frame
    //void Update()
    //{

    //}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Finish")
        {
            Win();
        }

        else
        {
            GameOver();
            Debug.Log("Game Over !!");
        }
        
    }

    void GameOver()
    {
        Destroy(this.gameObject);
    }

    void Win()
    {
        Time.timeScale = 0;
        Debug.Log("Win!!!!");
    }

}
