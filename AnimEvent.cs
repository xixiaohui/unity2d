using UnityEngine;
using System.Collections;

public class AnimEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.LeftArrow))
	    {
            //Debug.Log("Left Arrow");
	    }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //Debug.Log("Right Arrow");
        }
	}

    void event_A()
    {
        //Debug.Log("event a");
    }

    void event_B()
    {
        //Debug.Log("event b");
    }
}
