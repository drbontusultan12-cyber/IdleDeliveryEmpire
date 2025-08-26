using UnityEngine;

namespace IdleDeliveryEmpire.Core
{
    [CreateAssetMenu(menuName="IDE/Currency")]
    public class Currency : ScriptableObject
    {
        public string displayName = "Cash";
        public double amount = 0;

        public void Add(double v) => amount += v;

        public bool TrySpend(double v)
        {
            if (amount >= v)
            {
                amount -= v;
                return true;
            }
            return false;
        }
    }
}
