using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public GameObject self;
    private Score Scorenum;
    [SerializeField] private int currentHealth;
    [SerializeField] private bool EnemyDied = false;
    public Animator Animate;
    public GameObject ItemDrop;
    private Score ScoreManager;
    public GameObject hitEffect;
    public GameObject floatingPoints;
    public AudioClip deadSound;
    

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
        ScoreManager = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        //Animate.SetTrigger("Hurt");
        currentHealth -= damage;
        Instantiate(floatingPoints, transform.position, Quaternion.identity);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        EnemyDied = true;
        Debug.Log("Enemy dead");
        StartCoroutine(WaitForDestroy());
        


        if (EnemyDied)
        {
            if (this.gameObject.tag == "GreenPig")
            {
                Debug.Log("GreenPig died");
                ScoreManager.ScoreNum += 40;
                AudioSource.PlayClipAtPoint(deadSound, transform.position);
            }
            else if (this.gameObject.tag == "PurplePig")
            {
                Debug.Log("PurplePig died");
                ScoreManager.ScoreNum += 100;
                AudioSource.PlayClipAtPoint(deadSound, transform.position);
            }
            else if (this.gameObject.tag == "Skullman_Spear")
            {
                Debug.Log("Skullman Spear died");
                ScoreManager.ScoreNum += 200;
                AudioSource.PlayClipAtPoint(deadSound, transform.position);
            }
        }
    }

    private IEnumerator WaitForDestroy()
    {
        Animate.SetBool("isDead", true);
        yield return new WaitForSeconds(1.0f);
        Destroy(self);
        Instantiate(ItemDrop, this.transform.position, Quaternion.identity);
    }
}