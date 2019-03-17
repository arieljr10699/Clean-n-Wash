using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject soap;
    


    void Start()
    {
        Instantiate(soap, soap.transform.position, soap.transform.rotation);
    }

   
}
