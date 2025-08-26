using UnityEngine;
using IdleDeliveryEmpire.Core;

namespace IdleDeliveryEmpire.Gameplay
{
    public class Depot : MonoBehaviour
    {
        public DeliveryVehicle vehicle;
        public Currency cash;

        void Awake()
        {
            if (vehicle != null)
                vehicle.OnDelivered += amt => cash.Add(amt);
        }
    }
}
