using UnityEngine;

public class BatFly : MonoBehaviour
{
    public float speed = 2f;           // Velocidad de vuelo
    public float patrolDistance = 3f;  // Distancia máxima de patrullaje

    private Vector2 initialPosition;
    private bool movingRight = true;   // AHORA comienza volando hacia la DERECHA
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        initialPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        Vector2 direction = movingRight ? Vector2.right : Vector2.left;
        transform.Translate(direction * speed * Time.deltaTime);

        if (movingRight && transform.position.x >= initialPosition.x + patrolDistance)
        {
            Flip();
        }
        else if (!movingRight && transform.position.x <= initialPosition.x - patrolDistance)
        {
            Flip();
        }
    }

    void Flip()
    {
        movingRight = !movingRight;
        spriteRenderer.flipX = !movingRight;  // Importante: invertir aquí
    }
}
