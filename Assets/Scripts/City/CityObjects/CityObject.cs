using UnityEngine;

namespace City.CityObjects
{
    [System.Serializable]
    public class CityObject
    {
        public GameObject objectToSpawn;

        protected Grid<CityGridObject> Grid;
        protected GameObject SpawnedObject;
        protected CityGridObject Up;
        protected CityGridObject Down;
        protected CityGridObject Right;
        protected CityGridObject Left;

        public virtual bool CanSpawn => true;

        public virtual void Spawn(int x, int y)
        {
            Grid = MapGenerator.Grid;
            SpawnedObject = Object.Instantiate(objectToSpawn, Grid.GetWorldPosition(x, y), Quaternion.identity);
        }

        protected virtual void DeSpawn()
        {
            if (SpawnedObject == null) return;
            Object.Destroy(SpawnedObject);
            SpawnedObject = null;
        }
    }
}