using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleScript2 : MonoBehaviour
{
    private const int IMPERFECTION_TO_BAR_RATIO = 1 / 14;
    private bool canBeAccessed = true;
    private int setCount = 0;
    private GameController gameController;


    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Prefab" || other.tag == "Brush" || other.tag == "PataGallo1" || other.tag == "PataGallo2")
        {
            return;
        }
        if (canBeAccessed)
        {
           gameController.setface(true);
            transform.localScale -= new Vector3(0.05f, 0.05f, 0.0f);
            setCount++;
            if (setCount >= 3)
            {

                Destroy(gameObject, 0.15f);
                GetComponent<AudioSource>().Play();
                gameController.removeFromImperfectionBar();

            }
        }
        canBeAccessed = false;
    }

    private void OnTriggerExit(Collider other)
    {
        gameController.setface(false);
        canBeAccessed = true;
    }


}
