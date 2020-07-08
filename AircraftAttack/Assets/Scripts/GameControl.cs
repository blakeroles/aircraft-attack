using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public bool gameOver = false;
    public float scrollSpeed;
    public float playerProjectileDamage;
    public float enemyProjectileDamage;
    public float minNumberOfEnemiesPerLevel;
    public float maxNumberOfEnemiesPerLevel;
    public float enemiesLeft;
    public GameObject levelCompleteCanvas;
    public Text levelText;
    public int levelNumber;
    public GameObject levelTextCanvas;
    public GameObject secondChanceCanvas;
    public GameObject continueButton;

    public GameObject enemyPrefab;
    public float playerMaxHealth;
    private GameObject enemy;
    private GameObject[] enemies;
    private float numberOfEnemiesForLevel;
    private float camHeight;
    private float camWidth;
    private float enemyXPosition;
    private float enemyYPosition;
    private float playerHealth;




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

        levelNumber = PlayerPrefs.GetInt("LevelNumber", 1);

        levelText.text = "LEVEL: " + levelNumber.ToString();

        playerHealth = playerMaxHealth;

        GenerateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesLeft <= 0)
        {
            Time.timeScale = 0f;
            levelCompleteCanvas.SetActive(true);
            levelTextCanvas.SetActive(false);
        }
    }

    public void PlayerDied()
    {
        gameOver = true;

        secondChanceCanvas.SetActive(true);
        levelTextCanvas.SetActive(false);

        if (PlayerPrefs.GetInt("GameContinued") == 1)
        {
            continueButton.SetActive(false);
        }
        Time.timeScale = 0f;
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

    public void checkPlayerHealth()
    {
        if (playerHealth <= 0)
        {
            GameControl.instance.PlayerDied();
        }
    }

    public void reducePlayerHealth()
    {
        Debug.Log(playerHealth.ToString());
        playerHealth -= GameControl.instance.enemyProjectileDamage;
        
        checkPlayerHealth();
    }
}
