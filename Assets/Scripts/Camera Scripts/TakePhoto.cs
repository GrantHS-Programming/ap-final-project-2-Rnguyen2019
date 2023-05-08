using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePhoto : MonoBehaviour
{
    private bool cameraOn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!cameraOn)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                cameraOn = true;
            }
        }

        if (cameraOn)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("kys");
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                cameraOn = false;
            }
        }
    }
}
