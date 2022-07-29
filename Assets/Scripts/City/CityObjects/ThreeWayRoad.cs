using UnityEngine;

namespace City.CityObjects
{
    [System.Serializable]
    public class ThreeWayRoad : StraightRoad
    {
        public override bool CanSpawn => (!Up.IsRoad && Right.IsRoad && Left.IsRoad && Down.IsRoad) ||
                                         (Up.IsRoad && !Right.IsRoad && Left.IsRoad && Down.IsRoad) ||
                                         (Up.IsRoad && Right.IsRoad && !Left.IsRoad && Down.IsRoad) ||
                                         (Up.IsRoad && Right.IsRoad && Left.IsRoad && !Down.IsRoad);


        protected override Vector3 GetRotation()
        {
            if (!Down.IsRoad)
                return new Vector3(0, 90, 0);
            if (!Left.IsRoad)
                return new Vector3(0, 180, 0);
            if (!Up.IsRoad)
                return new Vector3(0, -90, 0);
            return Vector3.zero;
        }
    }
}