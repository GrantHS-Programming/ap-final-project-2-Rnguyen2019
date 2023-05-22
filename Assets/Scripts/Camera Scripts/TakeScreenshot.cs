using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeScreenshot : MonoBehaviour
{

    GameObject mainUI;

    // Start is called before the first frame update
    void Start()
    {
        mainUI = GameObject.Find("Main View UI");
    }

    // Update is called once per frame
    private void Update()
    {
        mainUI.SetActive(true);
        bool cameraOn = CameraFunction.cameraOn;

        if (Input.GetKeyDown(KeyCode.T))
        {
            //ScreenCapture.CaptureScreenshot("test.png");
            // make code so image constantly refreshes

            if (cameraOn)
            {
                mainUI.SetActive(false);
                StartCoroutine(CoroutineScreenshot());
            }
        }
    }

    private IEnumerator CoroutineScreenshot()
    {
        yield return new WaitForEndOfFrame();

        int width = (int)(Screen.width);
        int height = (int)(Screen.height);
        Texture2D screenShotTexture = new Texture2D(width, height, TextureFormat.ARGB32, false);
        Rect rect = new Rect(0, 0, width, height);
        screenShotTexture.ReadPixels(rect, 0, 0);
        screenShotTexture.Apply();

        byte[] byteArray = screenShotTexture.EncodeToPNG();
        System.IO.File.WriteAllBytes(Application.dataPath + "/CameraScreenShot.png", byteArray);
    }
}
