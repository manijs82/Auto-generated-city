using UnityEditor;
using UnityEngine;

namespace City.Editor
{
    [CustomEditor(typeof(MapGenerator))]
    public class CityMapEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            if (GUILayout.Button("Generate Map"))
            {
                MapGenerator mapGenerator = (MapGenerator) target;
                mapGenerator.GenerateMap();
            }
        }
    }
}