using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float xMobileTapForce;
    public GameObject playerProjectilePrefab;
    public float playerProjectileSpawnRate;
    public float playerProjectileXOffset;
    public float playerYOffset;

    private float camWidth;
    private float camHeight;
    private float timeSinceLastPlayerProjectilePairSpawned;
    private GameObject leftPlayerProjectile;
    private GameObject rightPlayerProjectile;





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


        timeSinceLastPlayerProjectilePairSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver == false && timeSinceLastPlayerProjectilePairSpawned >= playerProjectileSpawnRate)
        {
            timeSinceLastPlayerProjectilePairSpawned = 0;
            SpawnPlayerProjectilePair();
        }
    }



    public void SpawnPlayerProjectilePair()
    {
        leftPlayerProjectile = (GameObject) Instantiate(playerProjectilePrefab, new Vector2(transform.position.x - playerProjectileXOffset, transform.position.y), Quaternion.identity);
        rightPlayerProjectile = (GameObject) Instantiate(playerProjectilePrefab, new Vector2(transform.position.x + playerProjectileXOffset, transform.position.y), Quaternion.identity);
    }
}
