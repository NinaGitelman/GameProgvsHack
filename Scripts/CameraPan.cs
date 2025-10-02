using UnityEngine;

public class CameraPan : MonoBehaviour
{
  
    public float mouseSensitivity = 100f;
    private float verticalRotation = 0f;
    public Transform playerBody;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        
        playerBody.Rotate(Vector2.up * mouseX);

        // Rotate up/down
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        // Apply vertical rotation and horizontal pan
        transform.localRotation = Quaternion.Euler(verticalRotation,
        mouseX + transform.localEulerAngles.y, 0f);

    }
}
