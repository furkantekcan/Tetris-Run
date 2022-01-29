using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

    private void ShakeCamera()
    {
        gameObject.transform.DOShakePosition(2).SetUpdate(true);
    }

    private void OnEnable()
    {
        PlayerMovement.onGameOver += ShakeCamera;
    }

    private void OnDisable()
    {
        PlayerMovement.onGameOver -= ShakeCamera;
    }
}
