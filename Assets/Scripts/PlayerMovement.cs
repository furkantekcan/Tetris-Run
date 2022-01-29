using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public GameObject MenuUI;
    private Rigidbody rb;

    public delegate void onGameOverAction();
    public static event onGameOverAction onGameOver;

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
        Time.timeScale = 0;
        if (onGameOver != null)
        {
            onGameOver();
        }
        Destroy(this.gameObject);
        MenuUI.SetActive(true); 
        MenuUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "GAME OVER";
    }

    void Win()
    {

        Time.timeScale = 0;

        MenuUI.SetActive(true); 
        MenuUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "WIN";

        Debug.Log("Win!!!!");
    }

}
