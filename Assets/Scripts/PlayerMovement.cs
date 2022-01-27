using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        Vector3 movement = transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
