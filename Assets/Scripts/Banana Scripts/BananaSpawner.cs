using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaSpawner : MonoBehaviour
{
    private static BananaSpawner _instance;
    public static BananaSpawner Instance
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

    public float onePerXSeconds;
    public GameObject bananaOriginal;

    float timer = 0;
    public int numBananas = 0;
    public int bananaCapCount;
    private bool bananaCap = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > onePerXSeconds)
        {
            createBananas();
            timer = 0;
        }
        if (numBananas >= bananaCapCount)
        {
            bananaCap = true;
        }
        else
        {
            bananaCap = false;
        }

    }

    void createBananas()
    {
        if (!bananaCap)
        {
            int randNum1 = Random.Range(-95, 95);
            int randNum2 = Random.Range(-145, 145);
            GameObject bananaClone = Instantiate(bananaOriginal, new Vector3(randNum1, bananaOriginal.transform.position.y, randNum2), bananaOriginal.transform.rotation);
            numBananas++;
        }
        
    }
}
