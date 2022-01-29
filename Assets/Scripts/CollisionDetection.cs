using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public delegate void CollisionAction();
    public static event CollisionAction onCollisionOccurs;

    private void OnCollisionEnter(Collision collision)
    {
        if (onCollisionOccurs != null)
        {
            onCollisionOccurs();
        }
    }
}
