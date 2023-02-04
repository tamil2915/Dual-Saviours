using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputCollector : MonoBehaviour
{
    [SerializeField]
    private Inputcontrols inputControls;

    public Player prince;
    public Player princess;

    private void OnEnable()
    {
        inputControls.Enable();    
    }

    private void OnDisable()
    {
        inputControls.Disable();
    }

    private void Awake()
    {
        inputControls = new Inputcontrols();

        inputControls.PrinceActionMap.Move.performed += ctx => PrinceMoved(ctx.ReadValue<Vector2>());
        inputControls.PrincessActionMap.Move.performed += ctx => PrincessMoved(ctx.ReadValue<Vector2>());
    }

    void PrinceMoved(Vector2 direction)
    {
        prince.GetPlayerInput(direction);
    }


    void PrincessMoved(Vector2 direction)
    {
        princess.GetPlayerInput(direction);
    }
}
