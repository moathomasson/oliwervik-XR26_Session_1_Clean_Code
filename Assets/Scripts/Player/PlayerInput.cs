using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public UnityEvent<Vector2> OnMove = new();
    public UnityEvent<float> OnRotate = new();
    public UnityEvent OnJump = new();

    void Update()
    {
        Vector2 movement = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        float mouseX = Input.GetAxis("Mouse X");

        OnMove.Invoke(movement);
        OnRotate.Invoke(mouseX);

        if (Input.GetButtonDown("Jump"))
            OnJump.Invoke();
    }
}
