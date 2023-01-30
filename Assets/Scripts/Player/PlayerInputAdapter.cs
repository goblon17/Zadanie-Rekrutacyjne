using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInputAdapter : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        playerMovement.SetDirection(context.ReadValue<Vector2>());
    }

    public void Quit(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SceneManager.LoadScene((int)ScenesEnum.MainMenu);
        }
    }
}
