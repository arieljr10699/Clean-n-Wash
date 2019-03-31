using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleScript3 : MonoBehaviour
{
    private const int IMPERFECTION_TO_BAR_RATIO = 1 / 14;
    private bool canBeAccessed = true;
    private GameController gameController;
    int setCount = 0;


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
        if (other.tag == "Prefab" || other.tag == "Soap")
        {
            return;
        }
        if (canBeAccessed)
        {
            gameController.setface(true);
            transform.localScale -= new Vector3(0.15f, 0.15f, 0.0f);
            setCount++;
            if (setCount >= 3)
            {

                Destroy(gameObject, 0.15f);
                GetComponent<AudioSource>().Play();
                if (gameObject.tag == "PataGallo1")
                {
                    gameController.setSpawn1(true);
                }
                if (gameObject.tag == "PataGallo2")
                {
                    gameController.setSpawn2(true);
                }
                gameController.removeFromImperfectionBar();

            }
        }
            canBeAccessed = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Soap")
        {
            return;
        }
        canBeAccessed = true;
    }


}
