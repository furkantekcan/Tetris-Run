using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWork : MonoBehaviour
{
    public Transform player;
    Vector3 offset;
    Vector3 currentPlayerPosition;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            currentPlayerPosition = player.position;
        }

        transform.position = currentPlayerPosition + offset;
    }
}
