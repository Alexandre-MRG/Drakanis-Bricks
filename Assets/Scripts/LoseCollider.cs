using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    public AudioClip liveLost;
    private Player player;
    private LevelManager levelManager;
    private Ball ball;

    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        levelManager = GameObject.FindObjectOfType<LevelManager>(); // A l'exécution du script on recherche le levelManager pour pouvoir charger la scène de défaite.
        ball = GameObject.FindObjectOfType<Ball>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(liveLost, transform.position, 0.7f);
        player.live--;
        ball.hasStarted = false;

        if (player.live <= 0)
        {
            levelManager.LoadLevel("Lose");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }
}
