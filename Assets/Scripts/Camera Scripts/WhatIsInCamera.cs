using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatIsInCamera : MonoBehaviour
{
    Camera camera;
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
        var bounds = mesh.bounds;
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
    }
}
