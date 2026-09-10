using UnityEngine;
using UnityEngine.InputSystem;

namespace TiltanMobileSummer2026
{
    public class ActionMapLister : MonoBehaviour
    {
        [SerializeField] private InputActionAsset inputActionAsset;

        private void Start()
        {
            if (inputActionAsset == null)
            {
                Debug.LogError("InputActionAsset is not assigned.");
                return;
            }

            foreach (var map in inputActionAsset.actionMaps)
            {
                Debug.Log($"Action Map: {map.name}");
                foreach (var action in map.actions)
                {
                    Debug.Log($"  Action: {action.name}");
                }
            }
        }
    }
}