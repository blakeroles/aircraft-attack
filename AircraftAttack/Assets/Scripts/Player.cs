using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float xMobileTapForce;
    public float playerHealth;

    private float camWidth;
    private float camHeight;



    // Start is called before the first frame update
    void Start()
    {
        Camera cam = Camera.main;
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect; 
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameControl.instance.gameOver)
        {
            float h = Input.GetAxis("Horizontal") * moveSpeed;
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * h);
            
            #if UNITY_ANDROID
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    if (touch.position.x < Screen.width/2)
                    {
                        GetComponent<Rigidbody2D>().AddForce(new Vector2(-xMobileTapForce, 0));
                    }
                    else if (touch.position.x > Screen.width/2)
                    {
                        GetComponent<Rigidbody2D>().AddForce(new Vector2(xMobileTapForce, 0));
                    }
                }
            #endif

            #if UNITY_IPHONE
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    if (touch.position.x < Screen.width/2)
                    {
                        GetComponent<Rigidbody2D>().AddForce(new Vector2(-xMobileTapForce, 0));
                    }
                    else if (touch.position.x > Screen.width/2)
                    {
                        GetComponent<Rigidbody2D>().AddForce(new Vector2(xMobileTapForce, 0));
                    }
                }
            #endif

            if (transform.position.x > 0.5f * camWidth)
            {
                transform.position = new Vector3(0.5f * camWidth, transform.position.y, transform.position.z);
            }

            if (transform.position.x < -0.5f * camWidth)
            {
                transform.position = new Vector3(-0.5f * camWidth, transform.position.y, transform.position.z);
            }

        }
    }

    public void checkHealth()
    {
        if (playerHealth <= 0)
        {
            GameControl.instance.PlayerDied();
        }
    }
}
