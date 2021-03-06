using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health_Sys : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool Player_Dead;
    public Health_Bar healthBar;
    public Animator Character_Ani;
    public int healthPickUp = 20;
    private Score ScoreManager;
    [SerializeField] private bool canTakeDamage;

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        Player_Dead = false;
        canTakeDamage = true;
        ScoreManager = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (currentHealth == 0)
        {
            Player_Dead = true;
            Character_Ani.SetBool("playerDead", true);
            Resources.UnloadUnusedAssets();
            SceneManager.LoadScene("YouFail");
            ScoreManager.ScoreNum = 0;
        }
        if (currentHealth >= 100)
        {
            currentHealth = 100;
        }
    }

    public void TakeDamage(int damage)
    {
        if (canTakeDamage == true)
        {
            
                currentHealth -= damage;
                Cine_Shake.Instance.ShakeCamera(5f, 1f);    
                Character_Ani.SetTrigger("isHurt");
                healthBar.SetHealth(currentHealth);
            
            
        }
        else if (canTakeDamage == false)
        {
            currentHealth = 100;
        }
    }

    public void Invicibility(bool noDmg)
    {
        canTakeDamage = false;
        StartCoroutine(Wait());
    }

    public void TakePortion(int healthPickup)
    {
        currentHealth += healthPickup;

        healthBar.SetHealth(currentHealth);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Heart")
    //    {
    //        currentHealth += healthPickUp;
    //        Debug.Log("health boosted");
    //        heart.SetActive(false);
    //    }
    //}

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(3.0f);
        canTakeDamage = true;
        Debug.Log("tiMER OUT");
    }
}