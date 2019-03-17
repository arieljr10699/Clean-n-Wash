using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour {

    public float distance;
    public GameObject happy;
    public GameObject sad;
    private bool Switch = false;

    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3
               (
               Input.mousePosition.x,
               Input.mousePosition.y,
               distance
         );
        Vector3 objPosition = (Camera.main.ScreenToWorldPoint(mousePosition));
        transform.position = objPosition;

    }

    private void Update()
    {
        if(Input.GetButton("Jump"))
            {
                if (!Switch)
                {
                    happy.SetActive(false);
                    sad.SetActive(true);
                    Switch = true;
                }
                else
                {
                    happy.SetActive(true);
                    sad.SetActive(false);
                    Switch = false;
                }
            }
    }
}
