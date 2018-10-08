using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortCamScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        float width = Screen.width;
        float height = Screen.height;
        float ar = Mathf.RoundToInt((width / height) * 100f) / 100f;
        if (ar == 0.75f)
        {
            ar = 0.65f;
        }
        gameObject.GetComponent<Camera>().aspect = ar;
	}
	
}
