using UnityEngine;
using UnityEngine.InputSystem;

namespace TiltanMobileSummer2026
{
    public class PlayerInputController : MonoBehaviour
    {
        [SerializeField] private InputActionAsset inputAsset;
        private InputAction moveAction;
        private InputAction jumpAction;
        private Vector2 moveInput;

        /*
         * NOTE: Registering and Unregistering Events
         * - Registering (Subscribing): Using the '+=' operator binds a method to an event.
         *   When the event triggers, the registered method executes automatically.
         * - Unregistering (Unsubscribing): Using the '-=' operator detaches the method.
         *   This is required in OnDisable to prevent memory leaks and dangling references.
         */
        private void OnEnable()
        {
            var gameplayMap = inputAsset.FindActionMap("Gameplay");
        
            moveAction = gameplayMap.FindAction("Move");
            jumpAction = gameplayMap.FindAction("Jump");

            moveAction.Enable();
            jumpAction.Enable();

            // Registering response functions
            moveAction.performed += OnMovePerformed;
            jumpAction.performed += OnJumpPerformed;
        }

        private void OnDisable()
        {
            // Unregistering response functions
            moveAction.performed -= OnMovePerformed;
            jumpAction.performed -= OnJumpPerformed;

            moveAction.Disable();
            jumpAction.Disable();
        }

        /*
         * NOTE: Response Functions (Callbacks)
         * - These methods handle the actions when triggered.
         * - They take an 'InputAction.CallbackContext' parameter which provides state data,
         *   such as action phases (Started, Performed, Canceled) and input data values.
         */
        private void OnMovePerformed(InputAction.CallbackContext context)
        {
            moveInput = context.ReadValue<Vector2>();
        }

        private void OnJumpPerformed(InputAction.CallbackContext context)
        {
            Debug.Log("Jump action performed.");
        }

        private void Update()
        {
            Vector3 movement = new Vector3(moveInput.x, 0f, moveInput.y);
            transform.Translate(movement * Time.deltaTime);
        }
    }
}