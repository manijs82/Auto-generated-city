using UnityEngine;

namespace City.CityObjects
{
    [System.Serializable]
    public class Building : StraightRoad
    {
        public override bool CanSpawn => true;

        protected override Vector3 GetRotation()
        {
            if(Right.IsRoad)
                return new Vector3(0, 90, 0);
            if(Down.IsRoad)
                return new Vector3(0, 180, 0);
            if(Left.IsRoad)
                return new Vector3(0, -90, 0);
            return Vector3.zero;
        }
    }
}