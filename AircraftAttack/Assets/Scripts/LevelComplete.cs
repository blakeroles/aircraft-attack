using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("TitleScene");
        PlayerPrefs.SetInt("LevelNumber", 1);
    }

    public void StartNextLevel()
    {
        SceneManager.LoadScene("MainScene");
        PlayerPrefs.SetInt("LevelNumber", GameControl.instance.levelNumber + 1);
    }
}
