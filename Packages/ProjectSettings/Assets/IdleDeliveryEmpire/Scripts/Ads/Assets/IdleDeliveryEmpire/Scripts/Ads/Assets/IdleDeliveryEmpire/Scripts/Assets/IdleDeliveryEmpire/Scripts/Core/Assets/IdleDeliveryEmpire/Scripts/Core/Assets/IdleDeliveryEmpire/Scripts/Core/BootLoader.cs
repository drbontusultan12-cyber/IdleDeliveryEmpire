using UnityEngine;
using UnityEngine.SceneManagement;

namespace IdleDeliveryEmpire.Core
{
    public class BootLoader : MonoBehaviour
    {
        [SerializeField] string nextScene = "Game";

        void Start()
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
