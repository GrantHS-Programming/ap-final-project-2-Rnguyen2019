using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaidBananas : MonoBehaviour
{
    public GameObject[] bounds;
    private int level = 1;
    private int paid;

    private bool mountains;
    private float mountainMultiplier = 1;
    private bool trees;
    private float treesMultiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int bananaCalc()
    {
        paid = (int)(5 * mountainMultiplier * treesMultiplier * level);
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

        trees = bounds[1].GetComponent<WhatIsInCamera>().inCamera;
        if (trees)
        {
            treesMultiplier = 1.2f;
        }
        else
        {
            treesMultiplier = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        setMultiplier();
        bananaCalc();
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (TakeScreenshot.timer > TakeScreenshot.cooldown)
            {
                for (int i = 0; i < paid; i++)
                {
                    Player.Instance.addBanana();
                }
            }
        }
    }
}
