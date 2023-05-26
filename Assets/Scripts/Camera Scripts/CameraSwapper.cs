using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCamera : MonoBehaviour
{
    public GameObject picture;
    public GameObject background;

    // Start is called before the first frame update
    void Start()
    {
        picture.gameObject.SetActive(false);
        background.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            picture.gameObject.SetActive(false);
            background.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            picture.gameObject.SetActive(true);
            background.gameObject.SetActive(true);
        }
    }
}
