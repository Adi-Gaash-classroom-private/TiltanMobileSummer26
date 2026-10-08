using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace TiltanMobileSummer2026
{
    public class WebAssetLoader : MonoBehaviour
    {
        private async void Start()
        {
            string url = "https://picsum.photos/200";
            Texture2D texture = await LoadTextureFromWebAsync(url);
        
            if (texture != null)
            {
                Debug.Log($"Loaded texture successfully. Width: {texture.width}");
            }
        }

        private async Task<Texture2D> LoadTextureFromWebAsync(string url)
        {
            using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(url))
            {
                UnityWebRequestAsyncOperation operation = request.SendWebRequest();
            
                while (!operation.isDone)
                {
                    await Task.Yield();
                }

                if (request.result == UnityWebRequest.Result.Success)
                {
                    return DownloadHandlerTexture.GetContent(request);
                }
                else
                {
                    Debug.LogError($"Error loading texture: {request.error}");
                    return null;
                }
            }
        }
    }
}