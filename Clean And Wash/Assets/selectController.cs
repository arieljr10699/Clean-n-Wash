using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectController : MonoBehaviour {

    public Button button;

	// Use this for initialization
	void Start () {
        button.enabled = false;	
	}
	
	// Update is called once per frame
	void Update () {
		if(Static.Level2lock == false)
        {
            button.enabled = true;
        }
	}
}
