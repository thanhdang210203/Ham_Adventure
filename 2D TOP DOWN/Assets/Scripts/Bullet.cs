using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LayerMask enemyLayer;
    public int bulletDamage = 40;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
   
       
        //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 0.6f);
        //GetComponent<EnemyHealth>().TakeDamage(bulletDamage);
    

    private void OnTriggerEnter2D(Collider2D enemyHit)
    {

        if (enemyHit.tag == "GreenPig")
        {
            enemyHit.GetComponent<EnemyHealth>().TakeDamage(bulletDamage);
            //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            //Destroy(effect, 0.6f);
            Destroy(this.gameObject);
        }
        else if (enemyHit.tag == "PurplePig")
        {
            enemyHit.GetComponent<EnemyHealth>().TakeDamage(bulletDamage);
            //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            //Destroy(effect, 0.6f);
            Destroy(this.gameObject);
        }
        if (gameObject.tag == "Border")
        {
            Destroy(this.gameObject);
        } 
        
    }
}