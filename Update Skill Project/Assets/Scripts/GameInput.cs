using System;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnPressKeyE;
    private PlayerInputAction playerInputAction;
    private void Awake()
    {
        playerInputAction = new PlayerInputAction();
        playerInputAction.Player.Enable();
        playerInputAction.Player.PickUp.performed += PickUp_performed;
    }

    private void PickUp_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPressKeyE?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMoveDirec()
    {
        Vector2 inputVector = playerInputAction.Player.Move.ReadValue<Vector2>();
        return inputVector;
    }
}
