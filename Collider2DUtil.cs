using UnityEditor;
using UnityEngine;

public static class Collider2DUtil
{
    [MenuItem("GameObject/2D Object/Isometric Tile")]
    public static GameObject CreateIsometricTile()
    {
        GameObject go = new GameObject("IsoTile");

        PolygonCollider2D polygon = go.AddComponent<PolygonCollider2D>();
        float sqrt3 = Mathf.Sqrt(3f);
        Vector2[] points = new Vector2[] { new Vector2(-sqrt3, 0f), new Vector2(0f, 1f), new Vector2(sqrt3, 0f), new Vector2(0f, -1f) };
        polygon.SetPath(0, points);
        Selection.activeGameObject = go;

        return go;
    }
}
