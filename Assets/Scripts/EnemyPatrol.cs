using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;               // Velocidad de movimiento
    public float patrolDistance = 3f;       // Distancia que caminará antes de voltearse

    private Vector2 initialPosition;
    private bool movingRight = true;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x >= initialPosition.x + patrolDistance)
            {
                Flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x <= initialPosition.x - patrolDistance)
            {
                Flip();
            }
        }
    }

    void Flip()
    {
        movingRight = !movingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;  // Invierte el sprite
        transform.localScale = scale;
    }
}
