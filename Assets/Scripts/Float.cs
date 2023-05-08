using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{

    private bool red = false;

    MeshRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        renderer.material.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("kys");
            if (!red)
            {
                renderer.material.color = Color.red;
                red = true;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (red)
            {
                renderer.material.color = Color.green;
                red = false;
            }
        }
    }
}
