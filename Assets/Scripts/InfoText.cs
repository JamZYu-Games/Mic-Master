using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InfoText : MonoBehaviour
{
    // Start is called before the first frame update
    bool gameOver;
    bool gameStart;
    void Start()
    {
        gameOver = false;
        gameStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver && !gameStart && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Text>().text = "";
            gameStart = true;
        }
        if (gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("mic");
        }
    }

    public void GameOver()
    {
        gameOver = true;
        gameStart = false;
        GetComponent<Text>().text = "Space to Restart";
    }
}
