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

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        EnemyDied = true;
        Debug.Log("Enemy dead");
        //Animate.SetBool("isDead", true);
        StartCoroutine(WaitForDestroy());
        self.SetActive(false);
        Instantiate(hitEffect, transform.position, Quaternion.identity);
        Instantiate(ItemDrop, this.transform.position, Quaternion.identity);
        
        if (EnemyDied)
        {
            if (this.gameObject.tag == "Skullman")
            {
                Debug.Log("Skullman died");
                ScoreManager.ScoreNum += 100;
            }
            else if (this.gameObject.tag == "SkullGuard")
            {
                Debug.Log("SkullGuard died");
                ScoreManager.ScoreNum += 150;
            }
            else if (this.gameObject.tag == "Skullman_Spear")
            {
                Debug.Log("Skullman Spear died");
                ScoreManager.ScoreNum += 200;
            }
        }
    }

    private IEnumerator WaitForDestroy()
    {
        
        yield return new WaitForSeconds(0.6f);
    }
}