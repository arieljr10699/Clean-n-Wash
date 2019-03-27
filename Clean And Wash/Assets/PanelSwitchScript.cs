using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelSwitchScript : MonoBehaviour {
    private const int FRAMES_PER_SECOND = 60;

    private int frameCount;
    private int wait = 6;
    public GameObject waitPanel;
    public GameObject N5Panel;
    public GameObject N4Panel;
    public GameObject N3Panel;
    public GameObject N2Panel;
    public GameObject N1Panel;


    void Start () {

       

    }
	
	void Update()
    {
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {

        frameCount++;

        if (frameCount == FRAMES_PER_SECOND)
        {
            wait--;
            switch (wait)
            {
                case 5:
                    GetComponent<AudioSource>().Play();
                    waitPanel.SetActive(false);
                    N5Panel.SetActive(true);

                    break;
                case 4:
                    N5Panel.SetActive(false);
                    N4Panel.SetActive(true);
                    break;
                case 3:
                    GetComponent<AudioSource>().Stop();
                    GetComponent<AudioSource>().Play();
                    N4Panel.SetActive(false);
                    N3Panel.SetActive(true);
                    break;
                case 2:
                    N3Panel.SetActive(false);
                    N2Panel.SetActive(true);

                    break;
                case 1:
                    N2Panel.SetActive(false);
                    N1Panel.SetActive(true);
                    break;
                case 0:
                    yield return new WaitForSeconds(0.5f);
                    N1Panel.SetActive(false);
                    SceneManager.LoadScene(2);
                    break;

            }
            frameCount = 0;
        }
    }
}
