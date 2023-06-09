using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeScreenshot : MonoBehaviour
{
    public float cooldown;
    public GameObject picture;
    Rect rect1;
    Sprite photoSprite;
    private float timer = 100;
    public static bool tookPhoto = false;

    GameObject mainUI;

    // Start is called before the first frame update
    void Start()
    {
        picture.GetComponent<Image>().sprite = null;
        mainUI = GameObject.Find("Main View UI");
    }

    // Update is called once per frame
    private void Update()
    {
        tookPhoto = false;
        timer += Time.deltaTime;
        mainUI.SetActive(true);
        picture.SetActive(true);

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (timer > cooldown)
            {
                mainUI.SetActive(false);
                picture.SetActive(false);
                StartCoroutine(CoroutineScreenshot());
                timer = 0;
                tookPhoto = true;
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

        picture.GetComponent<Image>().rectTransform.sizeDelta = new Vector2((width - 1) * 0.1f, (height - 1) * 0.1f);

        rect1 = new Rect(0, 0, screenShotTexture.width, screenShotTexture.height);
        photoSprite = Sprite.Create(screenShotTexture, rect1, new Vector2(0f, 0f));
        picture.gameObject.GetComponent<Image>().sprite = photoSprite;
    }
}
