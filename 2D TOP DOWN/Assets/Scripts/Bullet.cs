using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public LayerMask enemyLayer;
    public int bulletDamage = 40;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            Destroy(this.gameObject);
        }
        //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 0.6f);
        //GetComponent<EnemyHealth>().TakeDamage(bulletDamage);
    }

    private void OnTriggerEnter2D(Collider2D enemyHit)
    {
        if (enemyHit.tag == "Enemy")
        {
            enemyHit.GetComponent<EnemyHealth>().TakeDamage(bulletDamage);
            //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            //Destroy(effect, 0.6f);
            Destroy(this.gameObject);
        }
    }
}