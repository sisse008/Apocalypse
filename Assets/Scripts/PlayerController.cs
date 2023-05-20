using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerController : GravitationalCharacter, ICollect, IDamagable, IDoorOpener
{
    [SerializeField] protected float playerWalkSpeed = 5f;

    [SerializeField] HealthBarUIController healthBarController;

    [SerializeField] CoinsCountUIController coinsCountController;

    [SerializeField] KeyGrabbedUIController keyGrabbedUIController;

    [SerializeField] Transform playerCamera;

    [SerializeField] Transform bloodSpillPosition;

    public Transform BloodSpillPosition
    {
        get
        {
            if (bloodSpillPosition == null)
                bloodSpillPosition = transform;
            return bloodSpillPosition;
        }
    }

    public ParticleSystem BloodSpillParticlesPrefab 
    {
        get 
        {
            return GameManager.Instance.ReffrenceHolder.bloodSpillParticlesPrefab;
        }
    }

    public bool canOpenDoor { get;  set; }

    public UnityAction OnHurt { get; set; }
    public UnityAction OnDead { get; set; }

    public UnityAction OnOpenedDoor { get; set; }


    [Range(0, 1)]
    [SerializeField] float _health = 1;
    public float Health
    {
        get
        {
            if (_health < 0.0002)
                _health = 0;
            return _health;
        }
    }


    public int coinsCollected { get; private set; }

    protected virtual void OnEnable()
    {
        RuntimeInputHelper.AxisInputHold += PlayerMoveWithCam;

        RPGRuntimeInputHelper.JumpKeyPressed += Jump;

        OnOpenedDoor += () => canMove = false;

    }

    protected virtual void OnDisable()
    {
        RuntimeInputHelper.AxisInputHold -= PlayerMoveWithCam;

        RPGRuntimeInputHelper.JumpKeyPressed -= Jump;

        OnOpenedDoor -= () => canMove = false;
    }

    Vector3 direction;
    [Header("Player Jumping and Velocity")]
    public float turnCamTime = 0.1f;
    float turnCamVelocity;



    protected virtual void PlayerMoveWithCam(float horizontal_axis, float vertical_axis)
    {
        if (canMove == false)
            return;

        Vector3 direction = new Vector3(horizontal_axis, 0, vertical_axis).normalized;

        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg +
            playerCamera.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnCamVelocity, turnCamTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        MoveCharacterController(moveDirection.normalized * playerWalkSpeed * Time.deltaTime);
    }

    protected void PlayerMove(float horizontal_axis, float vertical_axis)
    {
        if (canMove == false)
            return;

        if (direction == null)
            direction = new Vector3();

        direction.x = horizontal_axis;
        direction.y = 0;
        direction.z = vertical_axis;

        direction = direction.normalized;

        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float smoothTargetAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnCamVelocity, turnCamTime);

        transform.rotation = Quaternion.Euler(0f, smoothTargetAngle, 0f);

        Vector3 moveDirection = Quaternion.Euler(0f, targetAngle,0f) * Vector3.forward;
        MoveCharacterController(moveDirection.normalized * playerWalkSpeed * Time.deltaTime);
    }

    public void OnCollect(CollectableItem item)
    {
        if (item.GetType() == typeof(Coin))
        {
            coinsCountController.UpdateCoinCount(++coinsCollected);
        }
        else if (item.GetType() == typeof(Key))
        {
            canOpenDoor = true;
            keyGrabbedUIController.UpdateIsKeyGrabbed(true);
        }
    }

    protected override void Jump()
    {
       base.Jump();
    }


    public void OnDamadge(float damage)
    {
        _health -= damage;
       
        if (Health == 0)
            Dead();
        else
            Hurt();

        healthBarController.UpdateHealthBar(Health);
        Instantiate(BloodSpillParticlesPrefab, bloodSpillPosition.position, bloodSpillPosition.rotation, bloodSpillPosition);
    }

    protected virtual void Hurt()
    {
       OnHurt?.Invoke();
    }

    protected virtual void Dead()
    {
        canMove = false;
        OnDead?.Invoke();
    }

    public override void FallToDeath()
    {
        Dead();
    }

}
