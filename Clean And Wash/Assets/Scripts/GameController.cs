using System.Collections;
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
    private int startWait = 1;
    private float spawnRate = 2;
    private int time = 60;
    private int wait = 3;
    private bool gameover;
    public GameObject zit,pataGallo1,pataGallo2;
    public Slider imperfectionBar;
    private int imperfectionCount;
    public GameObject HappyFace;
    public GameObject SadFace;
    public GameObject idkface;
    public Text timerText;
    private int frameCount;
    public Text waitlabel;
    public GameObject waitPanel;
    public GameObject N5Panel;
    public GameObject N4Panel;
    public GameObject N3Panel;
    public GameObject N2Panel;
    public GameObject N1Panel;
    public GameObject VictoryPanel;
    public GameObject GameOverPanel;
    private bool win = false;
    public AudioSource VictoryAudio;
    public AudioSource GameOverAudio;
    public AudioSource backgroundAudio;
    public AudioSource buttonAudio;
    public bool canSpawn1, canSpawn2;



    void Start()
    {

        imperfectionCount = 0;
        StartCoroutine(spawnWaves());
        gameover = false;
        updateTimer();
        canSpawn1 = true;
        canSpawn2 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameover)
        {
            frameCount++;

            if (frameCount == FRAMES_PER_SECOND)
            {
                    time--;
                    updateTimer();
                frameCount = 0;
                if(time == 0)
                {
                    gameover = true;
                    Static.Level2 = false;
                    Static.Level1 = false;
                    win = true;
                   backgroundAudio.Stop();
                    VictoryAudio.Play();
                }
            }
        }
        if (gameover)
        {
            if (win)
            {
                VictoryPanel.SetActive(true);

                frameCount++;

                if (frameCount == FRAMES_PER_SECOND)
                {
                    wait--;
                    if (wait == 0)
                    {
                        SceneManager.LoadScene(1);
                    }
                    frameCount = 0;

                }
            }
            else if (!win) { GameOverPanel.SetActive(true); }
        }
    }

    IEnumerator spawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (!gameover)
        {
            if (time > 30)
            {
                int randArea = (int)Random.Range(1.0f, 2.9f);
                InstantiateRandomZit();
                if (Static.Level2)
                {
                    if (randArea == 1 && canSpawn1)
                    {
                        Instantiate(pataGallo1, pataGallo1.transform.position, pataGallo1.transform.rotation);
                        canSpawn1 = false;
                    }
                    if (randArea == 2 && canSpawn2)
                    {
                        Instantiate(pataGallo2, pataGallo2.transform.position, pataGallo2.transform.rotation);
                        canSpawn2 = false;
                    }
                }
               
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
        if (Static.Level1)
        {
            switch (randArea)
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
            else if(Static.Level2)
        {
            switch (randArea)
            {
                case 1:
                    Vector3 spawnPosition1 = new Vector3
                        (
                        Random.Range(-0.71f, 1.23f),
                        Random.Range(1.02f, 1.54f),
                        -2.0f
                        );
                    Quaternion SpawnRotation1 = new Quaternion(0, 0, 0, 0);
                    Instantiate(zit, spawnPosition1, SpawnRotation1);
                    addToImperfectionBar();
                    break;
                case 2:
                    Vector3 spawnPosition2 = new Vector3
                       (
                       Random.Range(-0.9f, 1.25f),
                       Random.Range(-0.75f, -0.16f),
                       -2.0f
                       );
                    Quaternion SpawnRotation2 = new Quaternion(0, 0, 0, 0);
                    Instantiate(zit, spawnPosition2, SpawnRotation2);
                    addToImperfectionBar();
                    break;
                case 3:
                    Vector3 spawnPosition3 = new Vector3
                      (
                      Random.Range(-0.21f, 0.63f),
                      Random.Range(-1.65f, -1.39f),
                      -2.0f
                      );
                    Quaternion SpawnRotation3 = new Quaternion(0, 0, 0, 0);
                    Instantiate(zit, spawnPosition3, SpawnRotation3);
                    addToImperfectionBar();
                    break;
            }
        }
           

    }

    public void addToImperfectionBar()
    {
        imperfectionBar.value += IMPERFECTION_TO_BAR_RATIO;
        imperfectionCount++;

        if(imperfectionCount == 7)
        {
            HappyFace.SetActive(false);
            SadFace.SetActive(true);
        }
        if(imperfectionCount == 14)
        {
            gameover = true;
            Static.Level2 = false;
            Static.Level1 = false;
            backgroundAudio.Stop();
            GameOverAudio.Play();
        }
    }
    
    public void removeFromImperfectionBar()
    {
        imperfectionBar.value -= IMPERFECTION_TO_BAR_RATIO;
        imperfectionCount--;

        if (imperfectionCount == 6)
        {
            HappyFace.SetActive(true);
            SadFace.SetActive(false);
        }
    }

    void updateTimer()
    {
        timerText.text = "Time : " + time;

    }

    public void backToLevelSelect()
    {
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        buttonAudio.Play();
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(1);
    }

    public void setface(bool val)
    {
        if (imperfectionCount < 7) {
            HappyFace.SetActive(!val);
            idkface.SetActive(val);
        }
        else
        if (imperfectionCount > 6)
        {
            SadFace.SetActive(!val);
            idkface.SetActive(val);
        }
    }

    public void setSpawn1(bool val)
    {
        canSpawn1 = val;
    }
    public void setSpawn2(bool val)
    {
        canSpawn2 = val;
    }
}
