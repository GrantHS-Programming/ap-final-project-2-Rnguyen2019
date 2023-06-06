using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaidBananas : MonoBehaviour
{
    public GameObject[] bounds;
    private int level = 1;
    private int paid;

    private bool mountains;
    private float mountainMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int bananaCalc()
    {
        paid = (int)(5 * mountainMultiplier * level);
        return paid;
    }

    public void setMultiplier()
    {
        mountains = bounds[0].GetComponent<WhatIsInCamera>().inCamera;
        if (mountains)
        {
            mountainMultiplier = 1.5f;
        }
        else
        {
            mountainMultiplier = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        setMultiplier();
        bananaCalc();
        if (Input.GetKeyDown(KeyCode.T))
        {
            for (int i = 0; i < paid; i++)
            {
                Player.Instance.addBanana();
            }
        }
    }
}
