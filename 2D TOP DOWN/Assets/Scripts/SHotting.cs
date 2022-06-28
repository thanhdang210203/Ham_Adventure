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
    public GameObject addAmmo;
    public AudioClip pickUp;

    #endregion Public var

    #region Private var

    [SerializeField] private int currentBullet;
    [SerializeField] private bool ableToShoot = true;
    [SerializeField] private int lowAmmo;
    [SerializeField] private bool bulletIsLow = false;
    [SerializeField] private bool ableToReload = false;
    [SerializeField] private bool gun1Pickup = false;
    //[SerializeField] private bool canReload = false;

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
        AudioSource.PlayClipAtPoint(pickUp, this.transform.position);
        Destroy(addAmmo);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gun1)
        {
            gun1Pickup = true;
            ableToShoot = true;
            ableToReload = true;
            AudioSource.PlayClipAtPoint(pickUp, this.transform.position);
            currentBullet += 20;
            Destroy(gun1);
        }
    }
}