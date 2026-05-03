using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Code.Infrastructure.Input
{
    public class PlayerInputService : IInputService, InputSystem_Actions.IPlayerActions, System.IDisposable
    {
        public event UnityAction<Vector2> Move = delegate { };
        public event UnityAction<Vector2, bool> Look = delegate { };
        public event UnityAction<bool> Attack = delegate { };
        public event UnityAction<bool> Interact = delegate { };
        public event UnityAction<bool> Crouch = delegate { };
        public event UnityAction<bool> Action = delegate { };
        public event UnityAction<bool> Previous = delegate { };
        public event UnityAction<bool> Next = delegate { };
        public event UnityAction<bool> Sprint = delegate { };
        public event UnityAction Exit = delegate { };

        private InputSystem_Actions _inputActions;

        public void ClearPlayerActions()
        {
            Move = delegate { };
            Look = delegate { };
            Attack = delegate { };
            Interact = delegate { };
            Crouch = delegate { };
            Action = delegate { };
            Previous = delegate { };
            Next = delegate { };
            Sprint = delegate { };
            Exit = delegate { };
        }

        public void EnablePlayerActions()
        {
            if (_inputActions == null)
            {
                _inputActions = new InputSystem_Actions();
                _inputActions.Player.SetCallbacks(this);
            }

            _inputActions.Enable();
        }

        public void DisablePlayerActions()
        {
            if (_inputActions == null)
                return;

            _inputActions.Disable();
        }

        public void Dispose()
        {
            if (_inputActions == null)
                return;

            _inputActions.Player.SetCallbacks(null);
            _inputActions.Dispose();
            _inputActions = null;
        }

        public void OnMove(InputAction.CallbackContext context) =>
            Move.Invoke(context.ReadValue<Vector2>());

        public void OnLook(InputAction.CallbackContext context) =>
            Look.Invoke(context.ReadValue<Vector2>(), IsDeviceMouse(context));

        public void OnAttack(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    Attack.Invoke(true);
                    break;
                case InputActionPhase.Canceled:
                    Attack.Invoke(false);
                    break;
            }
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    Interact.Invoke(true);
                    break;
                case InputActionPhase.Canceled:
                    Interact.Invoke(false);
                    break;
            }
        }

        public void OnCrouch(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    Crouch.Invoke(true);
                    break;
                case InputActionPhase.Canceled:
                    Crouch.Invoke(false);
                    break;
            }
        }

        public void OnAction(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    Action.Invoke(true);
                    break;
                case InputActionPhase.Canceled:
                    Action.Invoke(false);
                    break;
            }
        }

        public void OnPrevious(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    Previous.Invoke(true);
                    break;
                case InputActionPhase.Canceled:
                    Previous.Invoke(false);
                    break;
            }
        }

        public void OnNext(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    Next.Invoke(true);
                    break;
                case InputActionPhase.Canceled:
                    Next.Invoke(false);
                    break;
            }
        }

        public void OnSprint(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    Sprint.Invoke(true);
                    break;
                case InputActionPhase.Canceled:
                    Sprint.Invoke(false);
                    break;
            }
        }

        public void OnExit(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Started)
                Exit.Invoke();
        }

        private static bool IsDeviceMouse(InputAction.CallbackContext context) =>
            context.control?.device is Mouse;
    }
}
