using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassTrigger : MonoBehaviour
{
    public delegate void playerPassedDelegate();
    public event playerPassedDelegate playerPassedEvent;

    private GamePlay gameplay;
    //// Start is called before the first frame update
    void Start()
    {
        gameplay = FindObjectOfType<GamePlay>();
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    private void OnTriggerEnter(Collider other)
    {
        //playerPassedEvent();
        if (other.gameObject.name == "Player")
        {
            gameplay.OnPlayerPassed();
        }
        
        Debug.Log(other.gameObject.name);
    }
}
