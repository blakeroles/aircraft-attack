using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public GameObject backgroundImage1 = null;
    public GameObject backgroundLargeStars1 = null;
    public GameObject backgroundImage2 = null;
    public GameObject backgroundLargeStars2 = null;
    public Camera mainCam = null;
    public bool trackingTarget = true;
    
    private float lastYPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastYPosition = 0;
        scaleBackgroundImageFitScreenSize();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (trackingTarget)
        {
            if (target.position.y > lastYPosition && target.GetComponent<Rigidbody2D>().velocity.y >= 0)
            {
                Vector3 targetPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
                transform.position = targetPos;
                lastYPosition = target.position.y;
            }
        }
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


        if (trackingTarget)
        {
            SpriteRenderer backgroundImageSR2 = backgroundImage2.GetComponent<SpriteRenderer>();
            SpriteRenderer backgroundLargeStarsSR2 = backgroundLargeStars2.GetComponent<SpriteRenderer>();

            float bg2ImgH = backgroundImageSR2.sprite.rect.height;
            float bg2ImgW = backgroundImageSR2.sprite.rect.width;
            float bgLS2ImgH = backgroundLargeStarsSR2.sprite.rect.height;
            float bgLS2ImgW = backgroundLargeStarsSR2.sprite.rect.width;

            float bg2Img_scale_ratio_Height = camHeight / bg2ImgH;
            float bg2Img_scale_ratio_Width = camWidth / bg2ImgW;
            float bgLS2Img_scale_ratio_Height = camHeight / bgLS2ImgH;
            float bgLS2Img_scale_ratio_Width = camWidth / bgLS2ImgW;

            backgroundImage2.transform.localScale = new Vector3(bg2Img_scale_ratio_Width, bg2Img_scale_ratio_Height, 1);
            backgroundLargeStars2.transform.localScale = new Vector3(bgLS2Img_scale_ratio_Width, bgLS2Img_scale_ratio_Height, 1);

            backgroundImage2.transform.position = new Vector3(mainCam.transform.position.x, mainCam.transform.position.y + mainCam.orthographicSize * 2.0f, 0);
            backgroundLargeStars2.transform.position = new Vector3(mainCam.transform.position.x, mainCam.transform.position.y + mainCam.orthographicSize * 2.0f, 0);
        }
    }
}
