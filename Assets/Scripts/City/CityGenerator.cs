using UnityEngine;

namespace City
{
    public class CityGenerator : MonoBehaviour
    {
        [SerializeField] private CitySciptableObject citySciptableObject;
        
        [SerializeField] private GameObject roadObj;
        [SerializeField] private GameObject buildingObj;
        
        private Grid<CityGridObject> _grid;
        
        public void GenerateCity()
        {
            _grid = MapGenerator.Grid;

            for (int x = 0; x < _grid.Width; x++)
            {
                for (int y = 0; y < _grid.Height; y++)
                {
                    CityGridObject cityObject = _grid.GetValue(x, y);
                    if(cityObject.IsSpawned)
                        return;
                    cityObject.IsSpawned = true;

                    switch (cityObject.ObjectType)
                    {
                        case CityGridObject.CityObjectType.Road:
                            SpawnRoad(x, y);
                            break;
                        case CityGridObject.CityObjectType.Building:
                            SpawnBuilding(x, y);
                            break;
                        case CityGridObject.CityObjectType.Pavement:
                            citySciptableObject.pavement.Spawn(x, y);
                            break;
                        case CityGridObject.CityObjectType.Grass:
                            citySciptableObject.grass.Spawn(x, y);
                            break;
                    }
                }
            }
        }

        private void SpawnRoad(int x, int y)
        {
            citySciptableObject.straightRoad.Spawn(x, y);
            citySciptableObject.turnRoad.Spawn(x, y);
            citySciptableObject.threeWayRoad.Spawn(x, y);
            citySciptableObject.fourWayRoad.Spawn(x, y);
        }
        
        private void SpawnBuilding(int x, int y)
        {
            citySciptableObject.building[Random.Range(0, citySciptableObject.building.Length)].Spawn(x, y);
        }
    }
}
