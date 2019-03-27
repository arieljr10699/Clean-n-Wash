using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class MenuScript : MonoBehaviour
{
    public GameObject title;
    public GameObject playButton;

    private const int FRAMES_PER_SEC = 60;
    private int frameCount;
    private int sec;
    private bool stop;
    private Vector2 values = new Vector2(0.0f,0.0f);



    void Start()
    {
        playButton.SetActive(false);
        sec = 0;
        frameCount = 0;
        stop = false;
    }


    void Update()
    {

        if (!stop)
        {
            frameCount++;
            if (frameCount == FRAMES_PER_SEC / 10)
            {
                frameCount = 0;
                sec++;
                values.x += 10.0f;
                values.y += 3.0f;
                title.GetComponent<Image>().rectTransform.sizeDelta = values;
            }
            if (sec == 30)
            {
                stop = true;
                playButton.SetActive(true);
            }
        }

    }

}
