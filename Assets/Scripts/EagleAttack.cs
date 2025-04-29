using UnityEngine;

public class EagleAttack : MonoBehaviour
{
    public float speed = 0.1f;  // Velocidad de vuelo

    void Update()
    {
        Fly();
    }

    void Fly()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);  // Vuela hacia la izquierda
    }
}
