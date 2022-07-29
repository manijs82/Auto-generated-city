using UnityEngine;

namespace Mani.Scripts
{
    public static class VectorCalculation
    {
        #region Direction

        public static Vector3 Direction(this Vector3 point1, Vector3 point2) => point2 - point1;

        public static float DirectionMagnitude(this Vector3 point1, Vector3 point2) => (point2 - point1).magnitude;

        public static Vector3 VectorDirection(Vector3 point1, Vector3 point2) => point2 - point1;

        public static float VectorDirectionMagnitude(Vector3 point1, Vector3 point2) => (point2 - point1).magnitude;

        #endregion
    }
}
