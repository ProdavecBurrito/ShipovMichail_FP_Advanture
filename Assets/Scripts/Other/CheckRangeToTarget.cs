using UnityEngine;


namespace Shipov_FP_Adventure
{
    public class CheckRangeToTarget : MonoBehaviour
    {
        public bool CheckinMinDistanceToObject(Transform target, float distance)
        {
            if ((transform.position - target.position).sqrMagnitude < distance * distance)
            {
                return true;
            }
            return false;
        }

        public bool CheckinOffDistanceToObject(Transform target, float distance)
        {
            if ((transform.position - target.position).sqrMagnitude > distance * distance)
            {
                return true;
            }
            return false;
        }
    }
}
