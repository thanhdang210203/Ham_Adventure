using System.Collections;
using UnityEngine;

public class EnenmyAI : MonoBehaviour
{
    #region Public vars
    public float speed;
    public float checkRadius;
    public float attackRadius;
    public float timeBTWShots;
    public float shootSpeed;
    public bool shouldRotate;
    public GameObject bulletParent;
    public GameObject bullet;
    public LayerMask whatIsPlayer;
    public Transform shootPoint;
    public Animator anim;
    public Vector3 dir;
    public float fireRate = 1f;
    public int bulletDam;
    public AudioClip shootingSound;
    #endregion Public vars

    #region Private vars
    [SerializeField] private bool isInChaseRange;
    [SerializeField] private bool isInAttackRange;
    [SerializeField] private bool isInMeeleRange;
    private Transform target;
    private Rigidbody2D self;
    private Vector2 movement;
    private float nextFireTIme;
    #endregion Private vars

    // Start is called before the first frame update
    private void Start()
    {
        self = GetComponent<Rigidbody2D>();

        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        anim.SetBool("isRunning", isInChaseRange);

        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;
        if (shouldRotate)
        {
            anim.SetFloat("X", dir.x);
            anim.SetFloat("Y", dir.y);
        }
    }

    private void FixedUpdate()
    {
        if (isInChaseRange && isInAttackRange)
        {
            MoveCharacter(movement);
            
        }
        if (isInAttackRange && nextFireTIme <= Time.time)
        {
            self.velocity = Vector2.zero;

            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(shootingSound, transform.position);
            nextFireTIme = Time.time + fireRate;

        }
    }

    private void MoveCharacter(Vector2 dir)
    {
        self.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }

    

    
}