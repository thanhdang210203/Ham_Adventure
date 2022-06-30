using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SHotting : MonoBehaviour
{
    #region Public var

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public int totalBullet;
    public AudioClip reload;
    public AudioClip bulletShoot;
    public AudioClip emty;
    public AudioClip pickUp;
    public int bulletInLevel;
    public int bulletoShottInLevel;
    public Text ammoDisplay;
    public GameObject gun1;
    #endregion Public var

    #region Private var

    public int currentBullet;
    [SerializeField] private bool ableToShoot = true;
    
    public bool ableToReload;
    //[SerializeField] private bool canReload = false;

    #endregion Private var

    private void Start()
    {
        currentBullet = bulletoShottInLevel;
        totalBullet = bulletInLevel;
        ableToReload = true;
    }

    // Update is called once per frame
    private void Update()
    {
        ammoDisplay.text = currentBullet + "/" + totalBullet;
        if (currentBullet >= 1)
        {
            ableToShoot = true;
        }
        else if (currentBullet <= 0)
        {
            ableToShoot = false;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (ableToShoot)
            {
                Shoot();
            }
            else if (!ableToShoot)
            {
                AudioSource.PlayClipAtPoint(emty, transform.position);
            }
        }
        if (Input.GetKey(KeyCode.R))
        {
            if (currentBullet <= 0)
            {
                Reload();
            }
            else
            {
                //AudioSource.PlayClipAtPoint(reload, this.transform.position);
                //Audio plays multiple times at once -> maybe display text
                Debug.Log("Still got some bullet there mate");
            }
        }
        if (totalBullet <= 0 && currentBullet <= 0)
        {
            ableToReload = false;
            ableToShoot = false;
        }
        else
        {
            ableToReload = true;
            ableToShoot = true;
        }
    }

    private void Shoot()
    {
        currentBullet--;
        AudioSource.PlayClipAtPoint(bulletShoot, transform.position);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D Player = bullet.GetComponent<Rigidbody2D>();
        //bullet.transform.position = (firePoint.position - Input.mousePosition) * Time.deltaTime;
        Player.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    private void Reload()
    {
        if (ableToReload)
        {
            AudioSource.PlayClipAtPoint(reload, this.transform.position);
            currentBullet += 20;
            totalBullet -= 20;
            Debug.Log("Reloading");
        }
        else
        {
            //AudioSource.PlayClipAtPoint(emty, this.transform.position);
            Debug.Log("Go fuck yourself");
        }
    }

    public void plusAmmo(int ammoplus)
    {
        totalBullet += ammoplus;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "gun1")
        {
            Debug.Log("Gun picked");
            currentBullet += 50;
            ableToReload = true;
            Destroy(gun1);
        }
    }

}