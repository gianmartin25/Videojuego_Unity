using UnityEngine;
using UnityEngine.Tilemaps;

public class CompressTilemap : MonoBehaviour
{
    void Start()
    {
        GetComponent<Tilemap>().CompressBounds();
    }
}
