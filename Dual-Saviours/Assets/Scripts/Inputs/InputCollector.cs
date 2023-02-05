using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputCollector : MonoBehaviour
{
    [SerializeField]
    private Inputcontrols inputControls;

    public RotationMovement princeMover;
    public RotationMovement princessMover;

    public UIManager gameManager;

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

        inputControls.PrinceActionMap.Move.canceled += ctx => PrinceStopped();
        inputControls.PrincessActionMap.Move.canceled += ctx => PrincessStopped();

    }

    void PrinceMoved(Vector2 direction)
    {
        if (gameManager.IsGameOver)
            return;
        //prince.StartMoving(direction);
        princeMover.StartMoving(new Vector2( -direction.y, -direction.x));
    }

    void PrinceStopped()
    {
        //prince.StopMoving();
        princeMover.StopMoving();
    }

    void PrincessMoved(Vector2 direction)
    {
        if (gameManager.IsGameOver)
            return;
        princessMover.StartMoving(new Vector2(-direction.y, -direction.x));
    }

    void PrincessStopped()
    {
        princessMover.StopMoving();
    }
}
