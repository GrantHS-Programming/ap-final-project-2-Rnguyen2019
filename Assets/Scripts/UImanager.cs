using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    private static UImanager _instance;
    public static UImanager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("UImanager is null.");
            }
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this; 
    }

    public Text bananaCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateBananaText(int bananas)
    {
        bananaCount.text = "" + bananas;
    }
}
