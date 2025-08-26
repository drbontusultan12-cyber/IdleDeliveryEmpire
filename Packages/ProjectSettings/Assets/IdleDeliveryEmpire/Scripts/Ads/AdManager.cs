using System;
using UnityEngine;

namespace IdleDeliveryEmpire.Ads
{
    // Stub ads so Cloud Build works now (we'll swap to real AdMob later)
    public class AdManager : MonoBehaviour
    {
        public static AdManager Instance { get; private set; }

        void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public bool ShowInterstitial()
        {
            Debug.Log("[Ads] Interstitial (stub)");
            return false;
        }

        public void ShowRewarded(Action onReward)
        {
            Debug.Log("[Ads] Rewarded (stub)");
            onReward?.Invoke();
        }
    }
}
