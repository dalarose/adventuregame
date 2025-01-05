using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private Animator characterAnimController;

    [SerializeField]
    private Transform characterTransform;

    [SerializeField]
    private float stepValue = 0.01f;

    private const string TRIGGER_ANIMATION_WALK = "isWalking";
    private MovementState currentMovementState;

    private enum MovementState
    {
        Idle,
        Walking,
    }

    private void Start()
    {
        updateCharMovement(MovementState.Idle);
    }

    void Update()
    {
        var currPos = characterTransform.position;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currPos.x -= stepValue;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            currPos.x += stepValue;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            currPos.y -= stepValue;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            currPos.y += stepValue;
        }
        else
        {
            // assume idle
            updateCharMovement(MovementState.Idle);
            return;
        }

        characterTransform.position = currPos;
        updateCharMovement(MovementState.Walking);
        
    }

    private void updateCharMovement(MovementState nextMovement)
    {
        if (currentMovementState == nextMovement)
        {
            return;
        }

        switch (nextMovement)
        {
            case MovementState.Idle:
                characterAnimController.SetBool(TRIGGER_ANIMATION_WALK, false);
                break;
            case MovementState.Walking:
                characterAnimController.SetBool(TRIGGER_ANIMATION_WALK, true);
                break;
        }

        currentMovementState = nextMovement;
    }
}
