using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RPGRuntimeInputHelper : RuntimeInputHelper
{

    public static UnityAction JumpKeyPressed;
    public static UnityAction WalkKeysReleased;


    protected override void Update()
    {
        base.Update();

        bool jump_key_down = Input.GetButtonDown("Jump"); // first frame

        if (jump_key_down)
            JumpKeyPressed?.Invoke();

        #region stop movement
        bool horizontal_axis_up = Input.GetButtonUp("Horizontal");
        bool vertical_axis_up = Input.GetButtonUp("Vertical");

        if (horizontal_axis_up && vertical_axis_hold == 0) // first frame - neather axis is pressed
        {
            WalkKeysReleased?.Invoke();
        }

        if (vertical_axis_up && horizontal_axis_hold == 0) // first frame - neather axis is pressed
        {
            WalkKeysReleased.Invoke();
        }

        if (horizontal_axis_up && vertical_axis_up) // first frame - neather axis is pressed
        {
            WalkKeysReleased.Invoke();
        }

        #endregion
    }
}
