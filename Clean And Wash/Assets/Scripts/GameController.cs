﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    private const float IMPERFECTION_TO_BAR_RATIO = 0.07f;
    private const int FRAMES_PER_SECOND = 60;

   /* private Vector3[] zitLocs =
    {
        new Vector3(-2.72f,-0.07f,0.0f),
        new Vector3(-2.06f,-3.41f,0.0f),
        new Vector3(0.06f,2.42f,0.0f),
        new Vector3(0.06f,-4.0f,0.0f),
        new Vector3(2.3f,0.36f,0.0f),
        new Vector3(1.61f,-3.55f,0.0f),
    };*/
    private int startWait = 7;
    private float spawnRate = 2;
    private int time = 60;
    private int wait = 6;
    private bool gameover;
    public GameObject zit;
    public Slider imperfectionBar;
    private int imperfectionCount;
    public GameObject HappyFace;
    public GameObject SadFace;
    public Text timerText;
    private int frameCount;
    public Text waitlabel;
    public GameObject waitPanel;



    void Start () {

        imperfectionCount = 0;
        StartCoroutine(spawnWaves());
        gameover = false;
        updateTimer();
	}

    // Update is called once per frame
    void Update()
    {
        if (!gameover)
        {
            frameCount++;

            if (frameCount == FRAMES_PER_SECOND)
            {
                wait--;
                switch (wait)
                {
                    case 5:
                        waitlabel.text = " 5";
                       
                        break;
                    case 4:
                        waitlabel.text = " 4";
                        break;
                    case 3:
                        waitlabel.text = "3";
                        break;
                    case 2:
                        waitlabel.text = "2";
                        break;
                    case 1:
                        waitlabel.text = "1";
                        break;
                    case 0:
                        waitlabel.text = "0";
                        waitPanel.SetActive(false);
                        break;
                }
                frameCount = 0;
                
                
                if (wait < 1)
                {
                    time--;
                    updateTimer();
                }
            }
        }
    }

    IEnumerator spawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (!gameover)
        {
            if (time > 30)
            {
                InstantiateRandomZit();
                yield return new WaitForSeconds(spawnRate);
            }
            else if(time <= 30)
            {
                InstantiateRandomZit();
                InstantiateRandomZit();
                yield return new WaitForSeconds(spawnRate);
            }

        }
    }

    void InstantiateRandomZit()
    {
            int randArea = (int)Random.Range(1.0f, 3.9f);
            
        switch(randArea)
        {
            case 1:
                Vector3 spawnPosition1 = new Vector3
                    (
                    Random.Range(-0.71f, 1.23f),
                    Random.Range(1.42f, 1.94f),
                    0.0f
                    );
                Quaternion SpawnRotation1 = new Quaternion(0, 0, 0, 0);
                Instantiate(zit, spawnPosition1, SpawnRotation1);
                addToImperfectionBar();
                break;
            case 2:
                Vector3 spawnPosition2 = new Vector3
                   (
                   Random.Range(-0.9f, 1.37f),
                   Random.Range(-0.82f, -0.12f),
                   0.0f
                   );
                Quaternion SpawnRotation2 = new Quaternion(0, 0, 0, 0);
                Instantiate(zit, spawnPosition2, SpawnRotation2);
                addToImperfectionBar();
                break;
            case 3:
                Vector3 spawnPosition3 = new Vector3
                  (
                  Random.Range(-0.21f, 0.91f),
                  Random.Range(-2.18f, -1.7f),
                  0.0f
                  );
                Quaternion SpawnRotation3 = new Quaternion(0, 0, 0, 0);
                Instantiate(zit, spawnPosition3, SpawnRotation3);
                addToImperfectionBar();
                break;
        }
           

    }

    public void addToImperfectionBar()
    {
        imperfectionBar.value += IMPERFECTION_TO_BAR_RATIO;
        imperfectionCount++;

        if(imperfectionCount == 6)
        {
            HappyFace.SetActive(false);
            SadFace.SetActive(true);
        }
        if(imperfectionCount == 14)
        {
            SceneManager.LoadScene(1);
        }
    }
    
    public void removeFromImperfectionBar()
    {
        imperfectionBar.value -= IMPERFECTION_TO_BAR_RATIO;
        imperfectionCount--;

        if (imperfectionCount == 5)
        {
            HappyFace.SetActive(true);
            SadFace.SetActive(false);
        }
    }

    void updateTimer()
    {
        timerText.text = "Time : " + time;

    }
}