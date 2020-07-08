using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float maxHealth;
    public GameObject enemyProjectilePrefab;
    public float enemyProjectileSpawnRate;
    public float enemyProjectileXOffset;

    private float health;
    private float timeSinceLastEnemyProjectileSpawned;
    private GameObject enemyProjectile;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            GameControl.instance.enemiesLeft -= 1;
        }

        timeSinceLastEnemyProjectileSpawned += Time.deltaTime;

        if (!GameControl.instance.gameOver && timeSinceLastEnemyProjectileSpawned >= enemyProjectileSpawnRate)
        {
            timeSinceLastEnemyProjectileSpawned = 0;
            SpawnEnemyProjectile();
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "PlayerProjectile")
        {
            health -= GameControl.instance.playerProjectileDamage;
        }
    }

    public void SpawnEnemyProjectile()
    {
        enemyProjectile = (GameObject) Instantiate(enemyProjectilePrefab, new Vector2(transform.position.x + enemyProjectileXOffset, transform.position.y), Quaternion.identity);
    }
}
