using UnityEngine;
using IdleDeliveryEmpire.Ads;

namespace IdleDeliveryEmpire.Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager I;
        public Currency cash;

        public double baseRatePerSecond = 1;
        public double productionMultiplier = 1;

        float t;

        void Awake()
        {
            I = this;
            DontDestroyOnLoad(gameObject);
        }

        void Update()
        {
            t += Time.deltaTime;
            if (t >= 1f)
            {
                int s = Mathf.FloorToInt(t);
                t -= s;
                cash.Add(baseRatePerSecond * productionMultiplier * s);
            }
        }

        public void OnWatchAdBoost()
        {
            AdManager.Instance.ShowRewarded(() => StartCoroutine(Boost()));
        }

        System.Collections.IEnumerator Boost()
        {
            productionMultiplier *= 2;
            yield return new WaitForSeconds(600); // 10 minutes
            productionMultiplier /= 2;
        }
    }
}
