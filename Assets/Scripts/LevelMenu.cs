using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] private Text lvlText;
    [SerializeField] private Text timer;
    [SerializeField] private Text goal;
    [SerializeField] private TMP_Text completeText;
    [SerializeField] private GameObject missionCompleted;
    private int checkLvl;
    private float runningTime;
    public bool speedUpItemSpawn = false;
    private Score level;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject danItem_0Prefab;
    private int tempTime;
    [SerializeField] private GameObject restartButton;

    void Start()
    {
        missionCompleted.SetActive(false);
        goal.text = "Collect 150 points before time runs out";
        checkLvl = 1;
        lvlText.text = "Level : " + checkLvl;
        runningTime = 0f;
        tempTime = 60;
        level = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<Score>();
        danItem_0Prefab.SetActive(false);
        
    }
    void Update()
    {
        timer.text = "Time : " + (int)runningTime;
        runningTime += Time.deltaTime;

        if(level.levelOne == true) //if level one is completed
        {
            checkLvl = 2;
            lvlText.text = "Level : " + checkLvl;
            runningTime = Time.deltaTime * 0;
            tempTime = 90;
            goal.text = "Collect 200 points before time runs out";
            missionCompleted.SetActive(true);
            completeText.text = "You have completed level one\n Press Enter to play next level";
            Time.timeScale = 0f;
            speedUpItemSpawn = true;
        }

        if(level.levelTwo == true)
        {
            checkLvl = 3;
            lvlText.text = "Level : " + checkLvl;
            runningTime = Time.deltaTime * 0;
            tempTime = 120;
            goal.text = "Collect 250 points before time runs out";
           
            missionCompleted.SetActive(true);
            completeText.text = "You have completed level two\n Press Enter to play next level";
            Time.timeScale = 0f;
            danItem_0Prefab.SetActive(true);
        }
        
        if(level.levelThree == true)
        {
            Debug.Log("Game Over!");
            runningTime = Time.deltaTime * 0;
            missionCompleted.SetActive(true);
            completeText.text = "GAME OVER!";
            level.points = 0;
            Time.timeScale = 0f;
        }
        

        if (Input.GetKeyDown(KeyCode.Return))
        {
            missionCompleted.SetActive(false);
            level.points = 0;
            level.textMesh.text = "Points : " + level.points;
            Time.timeScale = 1f;
        }
        LevelFailed();
        //Check Time limit

    }
    public void LevelFailed()
    {
        if (runningTime > tempTime)
        {
            missionCompleted.SetActive(true);
            completeText.text = "Oops Try again!";
            level.points = 0;
            level.textMesh.text = "Points : " + level.points;
            Time.timeScale = 0f;
            restartButton.SetActive(true);
        }
        else
        {
            restartButton.SetActive(false);
        }
    }

    public void Restart()
    {
        runningTime = 0f;
        missionCompleted.SetActive(false);
        Time.timeScale = 1f;
        level.points = 0;
        
    }

    public void QuitGame()
    {
        Debug.Log("quit game");
        Application.Quit();
    }
}
