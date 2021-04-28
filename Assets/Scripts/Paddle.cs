using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;
    public float minX = 1f;
    public float maxX = 15f;

    private Ball ball;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {

        if ((Input.GetKeyDown(KeyCode.LeftControl)) &&(Input.GetKeyDown(KeyCode.Alpha1)))
        {
            autoPlay = false;
        }
        else if ((Input.GetKeyDown(KeyCode.LeftControl)) && (Input.GetKeyDown(KeyCode.Alpha2)))
        {
            autoPlay = true;
        }

        if (!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPLay();
        }

        
	}

    void AutoPLay()
    {
        Vector3 paddlePos = new Vector3(this.transform.position.x, this.transform.position.y, 0f);

        Vector3 ballPos = ball.transform.position;

        paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);

        this.transform.position = paddlePos;
    }

    void MoveWithMouse()
    {
        Vector3 paddlePos = new Vector3(this.transform.position.x, this.transform.position.y, 0f);

        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

        paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX);

        this.transform.position = paddlePos;
    }
}
