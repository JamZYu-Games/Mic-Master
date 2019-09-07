using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject scoreText;

    private int point;
    // Start is called before the first frame update
    void Start()
    {
        point = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void UpdateScore()
    {
        scoreText.GetComponent<Text>().text = point.ToString();
    }

    public void GetPoint()
    {
        point++;
        UpdateScore();
    }

    public void LosePoint()
    {
        point--;
        UpdateScore();
    }
}
