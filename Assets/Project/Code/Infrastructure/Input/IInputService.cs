using UnityEngine;
using UnityEngine.Events;

namespace Code.Infrastructure.Input
{
    public interface IInputService
    {
        event UnityAction<Vector2> Move;
        event UnityAction<Vector2, bool> Look;
        event UnityAction<bool> Attack;
        event UnityAction<bool> Interact;
        event UnityAction<bool> Crouch;
        event UnityAction<bool> Action;
        event UnityAction<bool> Previous;
        event UnityAction<bool> Next;
        event UnityAction<bool> Sprint;
        event UnityAction Exit;

        void ClearPlayerActions();
        void EnablePlayerActions();
        void DisablePlayerActions();
    }
}
