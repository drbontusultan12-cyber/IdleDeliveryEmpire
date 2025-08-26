using UnityEngine;

namespace IdleDeliveryEmpire.Gameplay
{
    public class DeliveryVehicle : MonoBehaviour
    {
        public double capacity = 10;
        public float tripTime = 5f;
        float t;

        public System.Action<double> OnDelivered;

        void Update()
        {
            t += Time.deltaTime;
            if (t >= tripTime)
            {
                t = 0;
                OnDelivered?.Invoke(capacity);
            }
        }
    }
}
