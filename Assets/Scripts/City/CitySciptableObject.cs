using City.CityObjects;
using UnityEngine;

namespace City
{
    [CreateAssetMenu(fileName = "City", menuName = "City", order = 0)]
    public class CitySciptableObject : ScriptableObject
    {
        public StraightRoad straightRoad;
        public TurnRoad turnRoad;
        public ThreeWayRoad threeWayRoad;
        public FourWayRoad fourWayRoad;
        [Space] 
        public Building[] building;
        [Space]
        public CityObject grass;
        public CityObject pavement;
    }
}