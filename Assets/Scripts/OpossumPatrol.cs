using UnityEngine;

public class OpossumPatrol : MonoBehaviour
{
    public float speed = 2f;            // Velocidad del opossum
    public float patrolDistance = 3f;   // Distancia a recorrer antes de voltearse

    private Vector2 initialPosition;    // Posición inicial para referencia
    private bool movingRight = false;   // Comienza mirando a la izquierda
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
        // Mover a la derecha o izquierda
        Vector2 direction = movingRight ? Vector2.right : Vector2.left;
        transform.Translate(direction * speed * Time.deltaTime);

        // Verificar si debe voltear
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
        spriteRenderer.flipX = movingRight;  // flipX activo cuando va a la derecha
    }
}
