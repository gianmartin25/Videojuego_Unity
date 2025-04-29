using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 6f;
    public float fuerzaRebote = 4f;
    public float longitudRaycast = 0.2f;
    public LayerMask capaSuelo;
    private bool enSuelo;
    private bool recibiendoDanio;
    private Rigidbody2D rigidbody;
    public Animator animator;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float velocidadX = Input.GetAxis("Horizontal") * velocidad;
        animator.SetFloat("movement", Mathf.Abs(velocidadX)); 

        if (velocidadX < 0) { transform.localScale = new Vector3(-1, 1, 1); }
        if (velocidadX > 0) { transform.localScale = new Vector3(1, 1, 1); }

        Vector3 posicion = transform.position;
        transform.position = new Vector3(velocidadX * Time.deltaTime + posicion.x, posicion.y, posicion.z);

        if (GameManager.instance != null)
        {
            GameManager.instance.MoverFondo(velocidadX);
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, longitudRaycast, capaSuelo);
        enSuelo = hit.collider != null;

        if (enSuelo && Input.GetKeyDown(KeyCode.Space) && !recibiendoDanio)
        {
            rigidbody.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
        }
        animator.SetBool("ensuelo", enSuelo);
        animator.SetBool("recibiendoDanio", recibiendoDanio);
    }
    public void RecibeDanio(Vector2 direccion, int cantDanio)
    {
        if(!recibiendoDanio)
        {
            recibiendoDanio = true;
            Vector2 rebote = new Vector2(transform.position.x - direccion.x, 1).normalized;
            rigidbody.AddForce(rebote*fuerzaRebote, ForceMode2D.Impulse);
        }
    }
    public void DesactivaDanio()
    {
        recibiendoDanio=false;
    }
   
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * longitudRaycast);
    }

}
