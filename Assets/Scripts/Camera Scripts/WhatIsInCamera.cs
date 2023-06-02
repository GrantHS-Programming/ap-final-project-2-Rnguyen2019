using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatIsInCamera : MonoBehaviour
{
    /*Camera camera;
    MeshRenderer renderer;
    Plane[] cameraFrustum;
    Collider collider;
    Mesh mesh;
    
    public bool inCamera = false;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Second Camera").GetComponent<Camera>();
        renderer = GetComponent<MeshRenderer>();
        collider = GetComponent<Collider>();
        mesh = GetComponent<Mesh>();
    }

    // Update is called once per frame
    void Update()
    {
        var bounds = collider.bounds;
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(camera);
        if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds))
        {
            renderer.material.color = Color.green;
            inCamera = true;
        }
        else
        {
            renderer.material.color = Color.red;
            inCamera = false;
        }
    }*/

    public GameObject target;
    public Camera cam;
    public GameObject boundsDetection;
    public bool inCamera = false;
    Plane[] planes;

    private bool isVisible(Camera c, GameObject target)
    {
        planes = GeometryUtility.CalculateFrustumPlanes(c);
        var point = target.transform.position;

        foreach(var plane in planes)
        {
            if (plane.GetDistanceToPoint(point) < 0 )
            {
                return false;
            }
        }
        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.Equals("boundsDetection"))
        {
            Debug.Log("kys");
        }
    }

    private void Update()
    {
        var targetRender = target.GetComponent<Renderer>();
        if (isVisible(cam, target))
        {
            targetRender.material.SetColor("_Color", Color.cyan);
            inCamera = true;
        }
        else
        {
            targetRender.material.SetColor("_Color", Color.yellow);
            inCamera = false;
        }
    }
}
