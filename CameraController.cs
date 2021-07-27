using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cam;
    public CharacterController controller;
    public float mouseSensitivity = 100f;
    public float speed = 100f;

    private float xRotation = 0f;
    private Vector3 move;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        // Locks Mouse Cursor in Game Window
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        KeyboardMovement();
        MouseLook();
    }

    private void KeyboardMovement()
    {
        float x = Input.GetAxisRaw("Horizontal"); // A & D keys
        float y = Input.GetAxisRaw("Vertical"); // W & S keys
        bool up = Input.GetKey("x");
        bool down = Input.GetKey("z");

        if (up)
            velocity.y = -speed;
        else if (down)
            velocity.y = speed;
        else
            velocity.y = 0f;

        move = (transform.right * x * speed) + (transform.forward * y * speed);
        controller.Move(velocity * speed * Time.deltaTime);
        controller.Move(move * Time.deltaTime * speed);
    }

    private void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
