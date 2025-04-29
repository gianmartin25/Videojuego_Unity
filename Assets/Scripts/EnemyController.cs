using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float detectionRadius = 5.0f;
    public float speed = 4.5f;

    private Rigidbody2D rigidbody2D;
    private Vector2 movement;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2D=GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer=Vector2.Distance(transform.position,player.position);

        if(distanceToPlayer < detectionRadius)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            movement = new Vector2(direction.x, 0);
            if (direction.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1); 
            }
            else if (direction.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1); 
            }
            animator.SetFloat("movement", Mathf.Abs(movement.x));
        }
        else
        {
            movement = Vector2.zero;
            animator.SetFloat("movement", 0f);
        }
        rigidbody2D.MovePosition(rigidbody2D.position+movement*speed*Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 direccionDanio = new Vector2(transform.position.x, 0);
            collision.gameObject.GetComponent<PlayerController>().RecibeDanio(direccionDanio, 1);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
