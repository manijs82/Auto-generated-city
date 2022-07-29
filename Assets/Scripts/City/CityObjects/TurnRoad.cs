using UnityEngine;

namespace City.CityObjects
{
    [System.Serializable]
    public class TurnRoad : StraightRoad
    {
        public override bool CanSpawn => (Up.IsRoad && Right.IsRoad && !Left.IsRoad && !Down.IsRoad) ||
                                         (Up.IsRoad && !Right.IsRoad && Left.IsRoad && !Down.IsRoad) ||
                                         (Down.IsRoad && !Right.IsRoad && Left.IsRoad && !Up.IsRoad) ||
                                         (Down.IsRoad && Right.IsRoad && !Left.IsRoad && !Up.IsRoad);


        protected override Vector3 GetRotation()
        {
            if (Up.IsRoad && Right.IsRoad)
                return new Vector3(0, 90, 0);
            if (Down.IsRoad && Right.IsRoad)
                return new Vector3(0, 180, 0);
            if (Down.IsRoad && Left.IsRoad)
                return new Vector3(0, -90, 0);
            return Vector3.zero;
        }
    }
}