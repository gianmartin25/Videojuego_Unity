using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;

[CustomEditor(typeof(Tilemap))]
public class TilemapTools : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Compress Bounds"))
        {
            Tilemap tilemap = (Tilemap)target;
            tilemap.CompressBounds();
        }
    }
}
