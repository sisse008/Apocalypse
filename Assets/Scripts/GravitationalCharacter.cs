using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public abstract class GravitationalCharacter : MonoBehaviour
{
    public static float gravity
    {
        get
        {
            return Physics.gravity.y;
        }
    }
    protected Vector3 velocity;

    [SerializeField] Transform surfaceCheck;

    [SerializeField] LayerMask surfaceMask;


    float surfaceDistance = 0.1f;
    protected bool canMove = true;


    CharacterController _characterController;
    protected CharacterController CharacterController
    {
        get
        {
            if (_characterController == null)
                _characterController = GetComponent<CharacterController>();
            return _characterController;
        }
    }

    public bool IsOnSurface()
    {
        RaycastHit hit;
        LayerMask mask = LayerMask.GetMask("Surface");
        if (Physics.Raycast(surfaceCheck.position, Vector3.down, out hit, mask))
        {
            if (surfaceCheck.position.y - hit.collider.transform.position.y < surfaceDistance)
                return true;
        }

        return false;
    }

    protected virtual void FixedUpdate()
    {
        MoveToGround();
    }

    void MoveToGround()
    {
        if (!IsOnSurface())
        {
            velocity.y += gravity * Time.deltaTime * 0.05f;
            MoveCharacterController(velocity, force:true);
        }
        else
        {
            if (velocity.y < 0)
            {
                velocity.y = 0f;
                MoveCharacterController(velocity);
            }
        }
    }

    protected virtual void Jump()
    {
        if (canMove == false)
            return;
        if (IsOnSurface())
        {
            velocity.y = Mathf.Sqrt(-0.005f * gravity);
            MoveCharacterController(velocity + transform.forward);
        }
        else 
        {
            Debug.LogError("Not on surface");
        }
    }

    public void MoveCharacterController(Vector3 destination, bool force = false) // need this for when die from virus and lay in mid air
    {
        if (canMove == false && force == false)
            return;
        CharacterController.Move(destination);
    }

    public virtual void FallToDeath()
    {
        canMove = false;
    }
}
