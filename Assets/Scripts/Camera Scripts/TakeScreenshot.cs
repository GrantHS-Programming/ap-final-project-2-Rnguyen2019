using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeScreenshot : MonoBehaviour
{
    public GameObject picture;
    Texture2D screenShotTexture;
    Rect rect1;
    Sprite photoSprite;

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
            if (cameraOn)
            {                mainUI.SetActive(false);
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
        int pictureWidth = (int)picture.GetComponent<Image>().sprite.rect.width;
        int wantWidth = Screen.width / pictureWidth * pictureWidth;
        int pictureHeight = (int)picture.GetComponent<Image>().sprite.rect.height;
        int wantHeight = Screen.height / pictureHeight * pictureHeight;
        Texture2D newScreenShotTexture = screenShotTexture.GetPixels((Screen.width - wantWidth) / 2, Screen.width - ((Screen.width - wantWidth) / 2), (Screen.height - wantHeight) / 2, (Screen.height - (Screen.height - wantHeight) / 2));
        Rect rect = new Rect(0, 0, width, height);
        screenShotTexture.ReadPixels(rect, 0, 0);
        screenShotTexture.Apply();

        byte[] byteArray = screenShotTexture.EncodeToPNG();
        System.IO.File.WriteAllBytes(Application.dataPath + "/CameraScreenShot.png", byteArray);

        rect1 = new Rect(0, 0, screenShotTexture.width, screenShotTexture.height);
        photoSprite = Sprite.Create(screenShotTexture, rect1, new Vector2(0f, 0f));
        picture.gameObject.GetComponent<Image>().sprite = photoSprite;
    }
}
