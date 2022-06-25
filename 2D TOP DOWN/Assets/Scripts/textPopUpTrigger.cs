using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textPopUpTrigger : MonoBehaviour
{
    public Collider2D triggerBox;
    public GameObject textPopUp;
    public float timeToDestroy = 2.0f;


    private void OnTriggerEnter2D(Collider2D triggerBox)
    {
        if(triggerBox.gameObject.tag == "Player")
        {
             Destroy(gameObject);
        }
    }
}
