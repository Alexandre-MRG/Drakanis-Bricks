using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    public bool hasStarted = false;

    private Paddle paddle;
    private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();     // A l'exécution du script, on recherche le gameObject de la plateforme.

        paddleToBallVector = this.transform.position - paddle.transform.position;   // Le vecteur reliant la boule & plateforme = la différence de leurs positions respectives 
	}
	
	// Update is called once per frame
	void Update () {
        if(!hasStarted)
        {
            // Lock the ball relative to the paddle 
            this.transform.position = paddle.transform.position + paddleToBallVector; 
        }

        // Wait for Click to launch
        if(Input.GetMouseButton(0))     // Clic gauche = on lance la boule en l'air à gauche.
        {
            if (!hasStarted)
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-2f, 10f);

            hasStarted = true;
        }
        else if (Input.GetMouseButton(1))   // Clic droit = on lance la boule en l'air à droite.
        {
            if (!hasStarted)
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);

            hasStarted = true;
        }
        
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        print(tweak);

        

        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }


}
