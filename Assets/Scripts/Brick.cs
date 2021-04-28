using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public AudioClip crack;
    public AudioClip destroyed;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public GameObject smoke;

    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;



    // Use this for initialization
    void Start ()
    {
        isBreakable = (this.tag == "Breakable");   // Si l'object porte le tag "Breakable, alors on peut le compter comme destructible.
        if (isBreakable)
        {
            breakableCount++;   // Pour chaque brique instanciée, on incrémente le nombre d'objets destructibles.
        }
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>(); // On recherche le levelManager dans la scène.
	}
	
	// Update is called once per frame
	void Update ()
    {

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHit++; // Une collision = 1 coup en +

        int maxHits = hitSprites.Length + 1; // Nombre max de coups = nombre de sprite endommagés + le sprite intact

        if (timesHit >= maxHits) // Si le nombre de coup est supérieur ou égal au nombre max de coups la brique est détruite
        {
            breakableCount--;   // On réduit le nombre d'objets destructible
            levelManager.CheckWin();    // On demande au levelManager de vérifier si la victoire est atteinte ou non
            AudioSource.PlayClipAtPoint(destroyed, transform.position, 0.7f);
            PuffSmoke();
            Destroy(gameObject);

        }
        else
        {
            AudioSource.PlayClipAtPoint(crack, transform.position, 1.0f);
            LoadSprites();  // Si la brique n'est pas détruite on charge son sprite endommagé correspondant
        }
    }

    void PuffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
        smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1; // On parcourt l'index de sprite à partir du nombre de coups.

        if (hitSprites[spriteIndex]) // Si le sprite existe, on le charge.
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];   // On change le sprite actuel par un nouveau endommagé.
        }
        else
        {
            Debug.LogError("Error : Unable to load brick's sprite.");
        }

    }

}
