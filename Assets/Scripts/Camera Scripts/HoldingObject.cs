using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingObject : MonoBehaviour
{
    [SerializeField] private LayerMask PickupMask;
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private Transform PickupTarget;
    [Space]
    [SerializeField] private float PickupRange;
    private Rigidbody CurrentObject;

    public float sensXY;

    float xRotation;
    float yRotation;

    public Transform orientation;

    float timer = 0;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CurrentObject)
            {
                CurrentObject.useGravity = true;
                CurrentObject = null;
                return;
            }

            Ray CameraRay = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, PickupRange, PickupMask))
            {
                CurrentObject = HitInfo.rigidbody;
                CurrentObject.useGravity = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (CurrentObject)
        {
            CurrentObject.freezeRotation = true;
            CurrentObject.freezeRotation = false;
            Vector3 DirectionToPoint = PickupTarget.position - CurrentObject.position;
            float DistancetoPoint = DirectionToPoint.magnitude;

            CurrentObject.velocity = DirectionToPoint * 12f * DistancetoPoint;
            if (Input.GetMouseButton(1))
            {
                float mouseX = Input.GetAxisRaw("Horizontal") / 5 * Time.deltaTime * sensXY;
                float mouseY = Input.GetAxisRaw("Vertical") / 5 * Time.deltaTime * sensXY;

                yRotation += mouseX;
                xRotation -= mouseY;
                Mathf.Clamp(xRotation, -90f, 90f);

                CurrentObject.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            }
            if (Input.GetMouseButton(2))
            {
                timer += Time.deltaTime;
                if (timer >= 10)
                {
                    timer = 10;
                }
            }
            if (!Input.GetMouseButton(2))
            {
                if (timer != 0)
                {
                    Vector3 moveDirection = orientation.forward * (10 + timer) + orientation.up * (2 + timer);
                    CurrentObject.GetComponent<Rigidbody>().AddForce(moveDirection * 100, ForceMode.Force);
                    CurrentObject.useGravity = true;
                    CurrentObject = null;
                    timer = 0;
                }
                
            }
        }
    }
}
