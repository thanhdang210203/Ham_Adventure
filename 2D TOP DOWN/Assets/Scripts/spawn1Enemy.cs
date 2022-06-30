using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn1Enemy : MonoBehaviour
{
    public GameObject enemy;
    public Transform spawnPoint;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Instantiate(enemy, spawnPoint.position, Quaternion.identity);
            Debug.Log("enemy apperaed");
        }
    }
}
