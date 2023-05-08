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
            Vector3 DirectionToPoint = PickupTarget.position - CurrentObject.position;
            float DistancetoPoint = DirectionToPoint.magnitude;

            CurrentObject.velocity = DirectionToPoint * 12f * DistancetoPoint;
            if (Input.GetMouseButton(1))
            {
                CurrentObject.freezeRotation = false;
                float mouseX = Input.GetAxisRaw("Horizontal") / 5 * Time.deltaTime * sensXY;
                float mouseY = Input.GetAxisRaw("Vertical") / 5 * Time.deltaTime * sensXY;

                yRotation += mouseX;
                xRotation -= mouseY;
                Mathf.Clamp(xRotation, -90f, 90f);

                CurrentObject.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            }
        }
    }
}
