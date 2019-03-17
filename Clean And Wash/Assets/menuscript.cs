using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class menuscript : MonoBehaviour
{

    private const int FRAMES_PER_SEC = 60;
    private int frameCount;
    private int sec;
    private bool stop;



    void Start()
    {
        sec = 0;
        frameCount = 0;
        stop = false;
    }


    void Update()
    {
       
       if (!stop)
        {
            frameCount++;
            if (frameCount == FRAMES_PER_SEC / 10 )
            {
                frameCount = 0;
                sec++;
                transform.localScale += new Vector3(0.05f, 0.05f, 0.0f);
            }
            if (sec == 30)
            {
                stop = true;
            }
        }
       
    }


}
