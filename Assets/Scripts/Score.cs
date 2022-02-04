using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int levelOneMaxPoints = 150;
    public bool levelOne;

    private int levelTwoMaxPoints = 200;
    public bool levelTwo;

    private int levelThreeMaxPoints = 250;
    public bool levelThree;

    public int points;
    public Text textMesh;

    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        LevelOneCompleted();
        LevelTwoCompleted();
        LevelThreeCompleted();
    }
    public void SetScore(int score)
    {
        audioSource.Play();
        this.points += score;
        textMesh.text = "Points : " + points;
        //if(this.points == levelOneMaxPoints)
        //{
        //    Debug.Log("Yeah u completed level_1");
        //    this.points = 0;
        //    levelOne = true;
        //}
    }

    public void LevelOneCompleted()
    {
        if (this.points == levelOneMaxPoints)
        {
            Debug.Log("Yeah u completed level_1");
            this.points = 0;
            levelOne = true;
            levelOneMaxPoints = 99999;
        }
        else
        {
            levelOne = false;
        }
    }

    public void LevelTwoCompleted()
    {
        if(this.points == levelTwoMaxPoints)
        {
            Debug.Log("yeah u completed level 2");
            this.points = 0;
            levelTwo = true;
            levelTwoMaxPoints = 99999;
        }
        else
        {
            levelTwo = false;
        }
    }

    public void LevelThreeCompleted()
    {
        if(this.points == levelThreeMaxPoints)
        {
            Debug.Log("yeah u completed level 3");
            this.points = 0;
            levelThree = true;
            levelThreeMaxPoints = 99999;
        }
        else
        {
            levelThree = false;
        }
    }
}
