using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public LayerMask Player;
    public int bulletDamage = 40;
    GameObject Target;
    public float speed;
    Rigidbody2D self;

    private void Start()
    {
        self = GetComponent<Rigidbody2D>();
        Target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (Target.transform.position - transform.position).normalized * speed;
        self.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 1);
    }
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "GreennPig")
        {
            Destroy(this.gameObject);
        }
        else if (gameObject.tag == "Border")
        {
            Destroy(this.gameObject);
        }
    }


    //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
    //Destroy(effect, 0.6f);
    //GetComponent<EnemyHealth>().TakeDamage(bulletDamage);


    private void OnTriggerEnter2D(Collider2D enemyHit)
    {

        if (enemyHit.tag == "Player")
        {
            enemyHit.GetComponent<Health_Sys>().TakeDamage(bulletDamage);
            Destroy(this.gameObject);
        }
        if (gameObject.tag == "Border")
        {
            Destroy(this.gameObject);
        }

    }
}