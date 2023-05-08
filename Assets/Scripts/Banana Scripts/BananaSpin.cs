using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaSpin : MonoBehaviour
{
    private float spinAngle = 0;
    public float spinIncrease;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, spinAngle, transform.eulerAngles.z);
        spinAngle += spinIncrease;
        if (spinAngle >= 360)
        {
            spinAngle = 0;
        }
    }
}
