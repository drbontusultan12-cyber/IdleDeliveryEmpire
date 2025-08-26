using UnityEngine;
using UnityEngine.UI;
using IdleDeliveryEmpire.Core;

namespace IdleDeliveryEmpire.UI
{
    public class HUDController : MonoBehaviour
    {
        public Text cashText;
        public Button watchAdButton;

        void Start()
        {
            if (watchAdButton)
                watchAdButton.onClick.AddListener(() => GameManager.I.OnWatchAdBoost());
        }

        void Update()
        {
            if (cashText && GameManager.I && GameManager.I.cash)
                cashText.text = $"Cash: {GameManager.I.cash.amount:0}";
        }
    }
}
