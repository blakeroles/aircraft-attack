using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject backgroundImage1 = null;
    public GameObject backgroundLargeStars1 = null;
    public Camera mainCam = null;
    

    // Start is called before the first frame update
    void Start()
    {
        scaleBackgroundImageFitScreenSize();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void scaleBackgroundImageFitScreenSize()
    {
        float srcHeight = Screen.height;
        float srcWidth = Screen.width;

        Vector2 deviceScreenResolution = new Vector2(srcWidth, srcHeight);

        float DEVICE_SCREEN_ASPECT = srcWidth / srcHeight;

        mainCam.aspect = DEVICE_SCREEN_ASPECT;

        float camHeight = 100.0f * mainCam.orthographicSize * 2.0f;
        float camWidth = camHeight * DEVICE_SCREEN_ASPECT;

        SpriteRenderer backgroundImageSR1 = backgroundImage1.GetComponent<SpriteRenderer>();
        SpriteRenderer backgroundLargeStarsSR1 = backgroundLargeStars1.GetComponent<SpriteRenderer>();      

        float bg1ImgH = backgroundImageSR1.sprite.rect.height;
        float bg1ImgW = backgroundImageSR1.sprite.rect.width;
        float bgLSImgH = backgroundLargeStarsSR1.sprite.rect.height;
        float bgLSImgW = backgroundLargeStarsSR1.sprite.rect.width;

        float bg1Img_scale_ratio_Height = camHeight / bg1ImgH;
        float bg1Img_scale_ratio_Width = camWidth / bg1ImgW;
        float bgLSImg_scale_ratio_Height = camHeight / bgLSImgH;
        float bgLSImg_scale_ratio_Width = camWidth / bgLSImgW;

        backgroundImage1.transform.localScale = new Vector3(bg1Img_scale_ratio_Width, bg1Img_scale_ratio_Height, 1);
        backgroundLargeStars1.transform.localScale = new Vector3(bgLSImg_scale_ratio_Width, bgLSImg_scale_ratio_Height, 1);

        backgroundImage1.transform.position = new Vector3(mainCam.transform.position.x, mainCam.transform.position.y, 0);
        backgroundLargeStars1.transform.position = new Vector3(mainCam.transform.position.x, mainCam.transform.position.y, 0);

    }
}
