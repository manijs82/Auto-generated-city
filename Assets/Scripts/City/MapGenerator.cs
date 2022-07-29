using Mani.Scripts;
using UnityEngine;

namespace City
{
    public class MapGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject plane;
        [Space]
        [SerializeField] private int scale;
        [SerializeField] private int width;
        [SerializeField] private int height;
        [SerializeField] private int mainBranches;
        [SerializeField] private int subBranches;
        
        public static Grid<CityGridObject> Grid;
    
        public void GenerateMap()
        {
            foreach (Transform tr in transform)
            {
                Destroy(tr.gameObject);
            }
            
            Grid = new Grid<CityGridObject>(width, height, scale, (grid, x, y) =>
            {
                GameObject obj = Utils.SpawnObject(plane, transform, new Vector3(x * scale, 0, y * scale), Vector3.one * scale);
                Destroy(obj.GetComponent<Collider>());
                return new CityGridObject(CityGridObject.CityObjectType.Grass, obj, x, y);
            });
            
            GenerationAlgorithms generators = new GenerationAlgorithms();
            generators.BranchAlgorithm(mainBranches, subBranches);
        }
    }
}
