using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class buttonscript : MonoBehaviour {

  

     public void test()
    {

        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(1);
    }
}
