using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject fondo;
    //public GameObject fondo2;
    private List<GameObject> fondos;
    private float velocidadFondo = 0f;
    private float tiempoPasado = 0f;

    public Color colorDia = new Color(0.5f, 0.8f, 1f); // Celeste 
    public Color colorNoche = new Color(0.2f, 0.3f, 0.5f); // Azul 
    void Awake()
    {
        instance = this;
    }


    void Start()
    {
        //for (int i = 0; i < 5; i++)
        //{
        //    fondos.Add(Instantiate(fondo, new Vector2(-10 + 29, 0), Quaternion.identity));
        //}
    }

    void Update()
    {
        
        //fondo.material.mainTextureOffset += new Vector2(velocidadFondo, 0) * Time.deltaTime;
        //tiempoPasado += Time.deltaTime;
        //if (tiempoPasado < 10f)
        //{
        //    fondo.material.color = Color.Lerp(fondo.material.color, colorDia, 0.5f * Time.deltaTime);
        //}
        //else if (tiempoPasado < 20f)
        //{
        //    fondo.material.color = Color.Lerp(fondo.material.color, colorNoche, 0.5f * Time.deltaTime);
        //}
        //else
        //{
        //    tiempoPasado = 0f; // Reiniciar
        //}
    }
    public void MoverFondo(float velocidadPersonaje)
    {
        //velocidadFondo = velocidadPersonaje * 0.02f;
    }
}