using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatIsInCamera : MonoBehaviour
{
    private GameObject boundsDetection;
    public bool inCamera = false;

    private void Start()
    {
         boundsDetection = GameObject.Find("BoundsDetector");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.Equals(boundsDetection.GetComponent<Collider>()))
        {
            inCamera = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        inCamera = false;
    }

    private void Update()
    {

    }
}
