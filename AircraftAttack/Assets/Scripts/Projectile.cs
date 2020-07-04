using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed;

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
        transform.position = new Vector3(transform.position.x, transform.position.y + projectileSpeed * Time.deltaTime, transform.position.z);

        if (transform.position.y > 0.5f * camHeight)
        {
            DestroyProjectile();
        }

    }

    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
