using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notiDes : MonoBehaviour
{
    public float timeToDestroy;
    public float WaitForPopUp;
    public GameObject PopUp;
    // Start is called before the first frame update

    private void Start()
    {
        PopUp.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.tag == "Player")
        {
            PopUp.SetActive(true);
            Destroy(this.gameObject, timeToDestroy);
        }   
    }
}
