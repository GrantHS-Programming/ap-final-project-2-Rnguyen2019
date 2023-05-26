using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFunction : MonoBehaviour
{
    private Camera ZoomCamera;

    public float sensXY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        ZoomCamera = Camera.main;
        Camera.main.fieldOfView = 60;

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        var mousePos = Input.mousePosition;
        mousePos.x -= Screen.width / 2;
        mousePos.y -= Screen.height / 2;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;

        if (Camera.main.fieldOfView > 100)
        {
            Camera.main.fieldOfView = 100;
        }

            Camera.main.fieldOfView += Input.GetAxis("Mouse ScrollWheel") * -15;

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensXY;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensXY;

        yRotation += mouseX;
        xRotation -= mouseY;
        Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
