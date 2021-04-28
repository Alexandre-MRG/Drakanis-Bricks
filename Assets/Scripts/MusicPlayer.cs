using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer instance = null;

    void Awake()
    {
        Debug.Log("Music Player Awake" + GetInstanceID());

        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            print("Instance set to this.");
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            print("Duplicate music player self-destructing!");
            Destroy(gameObject);
        }
        //Sets this to not be destroyed when reloading scene
        print("Don't destroy GOB");
        GameObject.DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start ()
    {
        Debug.Log("Music Player Start" + GetInstanceID());


	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
