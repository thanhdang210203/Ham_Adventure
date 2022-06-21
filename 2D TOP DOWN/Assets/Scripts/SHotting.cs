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

    #endregion Public var

    #region Private var

    [SerializeField] private int maxBulletPerMag = 20;
    [SerializeField] private int currentBullet;
    [SerializeField] private bool ableToShoot = true;
    [SerializeField] private int lowAmmo;
    [SerializeField] private bool bulletIsLow = false;
    [SerializeField] private bool ableToReload = false;

    #endregion Private var

    private void Start()
    {
        currentBullet = maxBulletPerMag;
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
        else if (Input.GetKey(KeyCode.R))
        {
            if (ableToReload)
            {
                Reload();
            }
            else if (!ableToReload)
            {
                AudioSource.PlayClipAtPoint(emty, transform.position);
            }
        }
    }

    private void Shoot()
    {
        currentBullet -= 1;
        AudioSource.PlayClipAtPoint(bulletShoot, transform.position);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D Player = bullet.GetComponent<Rigidbody2D>();
        Player.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    private void Reload()
    {
        AudioSource.PlayClipAtPoint(reload, transform.position);
        currentBullet += 20;
        totalBullet -= 20;
        Debug.Log("Reloading");
    }
}