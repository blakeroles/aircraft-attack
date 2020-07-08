using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondChance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ContinueGame()
    {

        if (PlayerPrefs.GetInt("GameContinued") == 0)
        {
            PlayerPrefs.SetInt("LevelNumber", GameControl.instance.levelNumber);
            PlayerPrefs.SetInt("GameContinued", 1);
        }
        else
        {
            PlayerPrefs.SetInt("LevelNumber", 1);
            PlayerPrefs.SetInt("GameContinued", 0);
        }

        SceneManager.LoadScene("MainScene");
    }
}
