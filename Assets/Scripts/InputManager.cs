using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    [HideInInspector] public float horizontalInput;
    [HideInInspector] public bool isReversing;
    [HideInInspector] public bool leftPressed;
    [HideInInspector] public bool rightPressed;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        HandleTouchInput();
    }

    void HandleTouchInput()
    {
        leftPressed = false;
        rightPressed = false;

        int activeTouches = 0;

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                activeTouches++;

                if (touch.position.x < Screen.width / 2)
                {
                    leftPressed = true;
                }
                else if (touch.position.x >= Screen.width / 2)
                {
                    rightPressed = true;
                }
            }
        }

        if (leftPressed && !rightPressed)
            horizontalInput = -1f;
        else if (rightPressed && !leftPressed)
            horizontalInput = 1f;
        else
            horizontalInput = 0f;

        isReversing = leftPressed && rightPressed;
    }
}
