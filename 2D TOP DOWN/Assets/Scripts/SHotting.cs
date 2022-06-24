using System.Collections;
using UnityEngine;

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
    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;
    public AudioClip pickUp;

    #endregion Public var

    #region Private var

    [SerializeField] private int currentBullet;
    [SerializeField] private bool ableToShoot = true;
    [SerializeField] private int lowAmmo;
    [SerializeField] private bool bulletIsLow = false;
    [SerializeField] private bool ableToReload = false;
    [SerializeField] private bool gun1Pickup = false;

    #endregion Private var

    private void Start()
    {
        currentBullet = 0;
        totalBullet = 0;
        ableToReload = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (currentBullet >= 1)
        {
            ableToShoot = true;
            ableToReload = false;
        }
        else if (currentBullet <= 0)
        {
            ableToShoot = false;
            ableToReload = true;
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
            if (ableToReload)
            {
                StartCoroutine(Reload());
            }
            else if (!ableToReload && ableToShoot)
            {
                //AudioSource.PlayClipAtPoint(emty, transform.position);
                //Audio plays multiple times at once -> maybe display text
                Debug.Log("Still got some bullet there mate");
            }
            else if (!ableToReload)
            {
                Debug.Log("Fuck u");
            }
        }
    }

    private void Shoot()
    {
        currentBullet--;
        AudioSource.PlayClipAtPoint(bulletShoot, transform.position);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D Player = bullet.GetComponent<Rigidbody2D>();
        Player.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    private IEnumerator Reload()
    {
        AudioSource.PlayClipAtPoint(reload, this.transform.position);
        yield return new WaitForSeconds(reload.length);
        currentBullet += 20;
        totalBullet -= 20;
        Debug.Log("Reloading");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gun1)
        {
            gun1Pickup = true;
            AudioSource.PlayClipAtPoint(pickUp, gun1.transform.position);
            currentBullet += 20;
            totalBullet += 100;
            Destroy(gun1);
        }
    }
}