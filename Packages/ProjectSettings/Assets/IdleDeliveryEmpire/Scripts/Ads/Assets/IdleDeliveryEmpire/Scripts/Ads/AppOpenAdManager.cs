using UnityEngine;

namespace IdleDeliveryEmpire.Ads
{
    public class AppOpenAdManager : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
