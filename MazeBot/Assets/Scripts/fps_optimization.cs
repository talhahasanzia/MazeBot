using UnityEngine;
using System.Collections;

public class fps_optimization : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Application.targetFrameRate = 300;
        QualitySettings.vSyncCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
       
	}
}
