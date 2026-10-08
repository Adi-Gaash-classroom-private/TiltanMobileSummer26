using UnityEngine;
using UnityEngine.SceneManagement;

namespace TiltanMobileSummer2026._Scripts
{
   

    public class AsyncLevelLoader : MonoBehaviour
    {
        [SerializeField] private string levelName;

        public void LoadLevel()
        {
            SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        }
    }
}