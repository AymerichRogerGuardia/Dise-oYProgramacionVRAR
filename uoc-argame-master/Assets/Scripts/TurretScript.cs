using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class TurretScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnhancedTouchSupport.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current?.leftArrowKey.isPressed == true || IsTouchingLeftSide())
        {
            MoveLeft();
        }

        if (Keyboard.current?.rightArrowKey.isPressed == true || IsTouchingRightSide())
        {
            MoveRight();
        }
    }

    bool IsTouchingLeftSide()
    {
        if (Touchscreen.current == null) return false;

        foreach (var touch in UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches)
        {
            if (touch.inProgress)
            {
                if (touch.screenPosition.x < Screen.width / 2)
                {
                    return true;
                }
            }
        }
        return false;
    }

    bool IsTouchingRightSide()
    {
        if (Touchscreen.current == null) return false;

        foreach (var touch in UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches)
        {
            if (touch.inProgress)
            {
                if (touch.screenPosition.x >= Screen.width / 2)
                {
                    return true;
                }
            }
        }
        return false;
    }

    void MoveLeft()
    {
        transform.Rotate(0, 0, 180 * Time.deltaTime);
    }

    void MoveRight()
    {
        transform.Rotate(0, 0, -180 * Time.deltaTime);
    }
}
