using TMPro;
using UnityEngine;

namespace Mani.Scripts
{
    public class Utils
    {
        public static GameObject SpawnObject(PrimitiveType type, Vector3 pos)
        {
            GameObject go = GameObject.CreatePrimitive(type);
            go.transform.position = pos;
            return go;
        }
        
        public static GameObject SpawnObject(PrimitiveType type, Transform parent, Vector3 pos)
        {
            GameObject go = GameObject.CreatePrimitive(type);
            go.transform.SetParent(parent);
            go.transform.position = pos;
            return go;
        }

        public static GameObject SpawnObject(PrimitiveType type, Transform parent, Vector3 pos, Vector3 scale)
        {
            GameObject go = GameObject.CreatePrimitive(type);
            go.transform.localScale = scale;
            go.transform.SetParent(parent);
            go.transform.position = pos;
            return go;
        }
        
        public static GameObject SpawnObject(GameObject gameObject, Transform parent, Vector3 pos, Vector3 scale)
        {
            GameObject go = Object.Instantiate(gameObject, parent, true);
            go.transform.localScale = scale;
            go.transform.position = pos;
            return go;
        }

        public static TextMeshPro CreateWorldText(string text, Transform parent = null, Vector3 localPos = default,
            int fontSize = 40, Color? color = null, TextAlignmentOptions textAlignment = TextAlignmentOptions.Center,
            int sortingOrder = 0)
        {
            if (color == null) color = Color.white;
            return CreateWorldText(text, parent, localPos, fontSize, (Color) color, textAlignment, sortingOrder);
        }

        public static TextMeshPro CreateWorldText(string text, Transform parent, Vector3 localPosition, int fontSize,
            Color color, TextAlignmentOptions textAlignment, int sortingOrder)
        {
            GameObject gameObject = new GameObject("world-text", typeof(TextMeshPro));
            Transform transform = gameObject.transform;
            transform.SetParent(parent, false);
            transform.localPosition = localPosition;
            TextMeshPro textMesh = gameObject.GetComponent<TextMeshPro>();
            textMesh.alignment = textAlignment;
            textMesh.text = text;
            textMesh.fontSize = fontSize;
            textMesh.color = color;
            textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
            return textMesh;
        }
    }
}