using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoseFol : MonoBehaviour
{
    private Vector2 mousePos;
    public Camera cam;
    public Rigidbody2D firePoint;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - firePoint.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        firePoint.rotation = angle;
    }
}
