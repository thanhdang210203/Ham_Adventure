using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAni : MonoBehaviour
{
    public Rigidbody2D Player;
    private Vector2 movement;
    public Animator ani;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        ani.SetFloat("Horizontal", movement.x);
        ani.SetFloat("Vertical", movement.y);
        ani.SetFloat("Speed", movement.sqrMagnitude);
    }
}
