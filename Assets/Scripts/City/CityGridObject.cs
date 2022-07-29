using UnityEngine;

namespace City
{
    public class CityGridObject
    {
        public enum CityObjectType
        {
            Road, Building, Pavement, Grass
        }

        public bool IsSpawned;
        public CityObjectType ObjectType;
        
        private int _xIndex;
        private int _yIndex;

        private Renderer _renderer;

        public bool IsRoad => ObjectType == CityObjectType.Road;

        public CityGridObject(CityObjectType objectType, GameObject gameObject, int x, int y)
        {
            ObjectType = objectType;
            _xIndex = x;
            _yIndex = y;

            _renderer = gameObject.GetComponent<Renderer>();
            _renderer.material.color = GetColor();
        }

        public void ChangeType(CityObjectType cityObjectType)
        {
            switch (cityObjectType)
            {
                case CityObjectType.Road:
                    MapGenerator.Grid.GetValue(_xIndex, _yIndex + 1).ChangeType(CityObjectType.Building);
                    MapGenerator.Grid.GetValue(_xIndex, _yIndex - 1).ChangeType(CityObjectType.Building);
                    MapGenerator.Grid.GetValue(_xIndex + 1, _yIndex).ChangeType(CityObjectType.Building);
                    MapGenerator.Grid.GetValue(_xIndex - 1, _yIndex).ChangeType(CityObjectType.Building);
                    MapGenerator.Grid.GetValue(_xIndex + 1, _yIndex + 1).ChangeType(CityObjectType.Building);
                    MapGenerator.Grid.GetValue(_xIndex - 1, _yIndex - 1).ChangeType(CityObjectType.Building);
                    MapGenerator.Grid.GetValue(_xIndex - 1, _yIndex + 1).ChangeType(CityObjectType.Building);
                    MapGenerator.Grid.GetValue(_xIndex + 1, _yIndex - 1).ChangeType(CityObjectType.Building);
                    break;
                case CityObjectType.Building:
                    if(ObjectType == CityObjectType.Road)
                        return;
                    MapGenerator.Grid.GetValue(_xIndex, _yIndex + 1).ChangeType(CityObjectType.Pavement);
                    MapGenerator.Grid.GetValue(_xIndex, _yIndex - 1).ChangeType(CityObjectType.Pavement);
                    MapGenerator.Grid.GetValue(_xIndex + 1, _yIndex).ChangeType(CityObjectType.Pavement);
                    MapGenerator.Grid.GetValue(_xIndex - 1, _yIndex).ChangeType(CityObjectType.Pavement);
                    MapGenerator.Grid.GetValue(_xIndex + 1, _yIndex + 1).ChangeType(CityObjectType.Pavement);
                    MapGenerator.Grid.GetValue(_xIndex - 1, _yIndex - 1).ChangeType(CityObjectType.Pavement);
                    MapGenerator.Grid.GetValue(_xIndex - 1, _yIndex + 1).ChangeType(CityObjectType.Pavement);
                    MapGenerator.Grid.GetValue(_xIndex + 1, _yIndex - 1).ChangeType(CityObjectType.Pavement);
                    break;
                case CityObjectType.Pavement:
                    if(ObjectType != CityObjectType.Grass)
                        return;
                    break;
                case CityObjectType.Grass:
                    break;
            }
            
            ObjectType = cityObjectType;
            _renderer.material.color = GetColor();
        }


        public Color GetColor()
        {
            return ObjectType switch
            {
                CityObjectType.Road => Color.gray,
                CityObjectType.Building => Color.blue,
                CityObjectType.Pavement => Color.cyan,
                CityObjectType.Grass => Color.green,
                _ => Color.white
            };
        }
    }
}
