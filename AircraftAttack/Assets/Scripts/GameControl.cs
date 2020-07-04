using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public bool gameOver = false;
    public float scrollSpeed;
    public float playerProjectileDamage;
    public float minNumberOfEnemiesPerLevel;
    public float maxNumberOfEnemiesPerLevel;
    public float enemiesLeft;
    public GameObject levelCompleteCanvas;

    public GameObject enemyPrefab;
    private GameObject enemy;
    private GameObject[] enemies;
    private float numberOfEnemiesForLevel;
    private float camHeight;
    private float camWidth;
    private float enemyXPosition;
    private float enemyYPosition;



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
        Camera cam = Camera.main;
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect; 
        Time.timeScale = 1f;
        GenerateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesLeft <= 0)
        {
            Time.timeScale = 0f;
            levelCompleteCanvas.SetActive(true);
        }
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
        numberOfEnemiesForLevel = (int) Random.Range(minNumberOfEnemiesPerLevel, maxNumberOfEnemiesPerLevel);
        enemies = new GameObject[(int) numberOfEnemiesForLevel];

        for (int i = 0; i < numberOfEnemiesForLevel; i++)
        {
            enemyXPosition = Random.Range(-0.5f*camWidth, 0.5f*camWidth);
            enemyYPosition = Random.Range(0, 0.5f*camHeight);
            enemies[i] = (GameObject) Instantiate(enemyPrefab, new Vector2(enemyXPosition, enemyYPosition), Quaternion.identity);
            enemies[i].transform.eulerAngles = new Vector3(180f, 0f, 0f);
        }

        enemiesLeft = numberOfEnemiesForLevel;
    }
}
