using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update

    public void NivelFacil() {
        Static.Level1 = true;
        StartCoroutine(Load());
    }

    public void NivelIntermedio()
    {
        Static.Level2 = true;
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(3);
    }
}
