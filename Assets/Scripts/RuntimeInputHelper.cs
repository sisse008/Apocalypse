using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RuntimeInputHelper : MonoBehaviour
{

    public static UnityAction<float, float> AxisInputHold;
    public static UnityAction Fire1Trigger;

    protected float horizontal_axis_hold;
    protected float vertical_axis_hold;

    protected virtual void Update()
    {
        horizontal_axis_hold = Input.GetAxisRaw("Horizontal");
        vertical_axis_hold = Input.GetAxisRaw("Vertical");

        if (horizontal_axis_hold != 0 || vertical_axis_hold != 0)
            AxisInputHold?.Invoke(horizontal_axis_hold, vertical_axis_hold);

        if (Input.GetButtonDown("Fire1"))
        {
            Fire1Trigger?.Invoke();
        }
    }
}
