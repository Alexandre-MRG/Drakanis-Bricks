using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public int live = 3;
    private Text text;


	// Use this for initialization
	void Start () {
        text = GameObject.FindObjectOfType<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = live.ToString();
	}


}
