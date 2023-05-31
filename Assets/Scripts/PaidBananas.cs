using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaidBananas : MonoBehaviour
{
    public GameObject[] bounds;

    private bool mountains;
    private float mountainMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
        int rand = Random.Range(1, 1);
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (mountains)
            {
                rand *= 2;
                Debug.Log("igoshe");
            }
            for (int i = 0; i < rand; i++)
            {
                Player.Instance.addBanana();
            }
        }
    }
}
