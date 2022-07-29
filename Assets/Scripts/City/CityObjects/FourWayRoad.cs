using UnityEngine;

namespace City.CityObjects
{
    [System.Serializable]
    public class FourWayRoad : StraightRoad
    {
        public override bool CanSpawn => Up.IsRoad && Right.IsRoad && Left.IsRoad && Down.IsRoad;


        protected override Vector3 GetRotation()
        {
            return Vector3.zero;
        }
    }
}