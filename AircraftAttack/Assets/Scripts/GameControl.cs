using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public bool gameOver = false;
    public float scrollSpeed;
    public float playerProjectileDamage;

    public GameObject enemyPrefab;
    private GameObject enemy;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerDied()
    {
        gameOver = true;
    }

    public void GenerateLevel()
    {
        GenerateEnemies();
    }

    public void GenerateEnemies()
    {
        enemy = (GameObject) Instantiate(enemyPrefab, new Vector2(0.0f, 0.0f), Quaternion.identity);
        enemy.transform.eulerAngles = new Vector3(180f, 0f, 0f);
    }
}
