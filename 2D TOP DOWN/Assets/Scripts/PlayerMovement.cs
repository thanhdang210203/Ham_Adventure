using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Public

    public float moveSpeed = 5.0f;
    public Rigidbody2D Player;
    public Camera cam;
    public AudioClip walking;

    #endregion Public

    private Vector2 movement;
    private Vector2 mousePos;

    // Update is called once per frame
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        Player.MovePosition(Player.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - Player.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        Player.rotation = angle;
    }
}