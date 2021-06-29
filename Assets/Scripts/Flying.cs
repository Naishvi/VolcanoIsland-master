
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying: MonoBehaviour
{

    /// <summary>
    /// Array that contains all of the currently active enemy objects.
    /// </summary>
    public GameObject[] bird;

    //private float min = -5f, max = 5f;

    /// <summary>
    /// Time to wait between spawning enemy objects.
    /// </summary>
    public float timeBetweenBirds;

    /// <summary>
    /// Minium allowable time between enemy spawn.
    /// </summary>
    public float minBirdTime;

    /// <summary>
    /// Amount of time to decrease the time between spawning over time.
    /// </summary>

    /// <summary>
    /// Triggers spawn when the value is <=0
    /// </summary>
    private float BirdTimer;


    /// <summary>
    /// sets the spawning timer to 0 so that an enemy will spawn immediately.
    /// </summary>
    void Start()
    {
        BirdTimer = 0f;
    }

    /// <summary>
    /// Spawns the enemy gameobjects. Uses the spawnTimer to determin when to
    /// spawn. If the player is dead, no spawns take place. As the game progresses,
    /// the time between spawns will decrease until a minimum value is reached.
    /// </summary>
    void Update()
    {
        
        //stop spawning if there is no character
        if (GameObject.FindGameObjectWithTag("Player") == null || GameObject.FindGameObjectWithTag("Player").activeSelf==false) {
            return;
        }
        if (BirdTimer <= 0) {
            float min = -5f;
            float max = 5f; 
            //spawn an enemy
            GameObject birdy = bird[Random.Range(0, bird.Length)];
            float value = Random.Range(min, max);
            Vector3 position = new Vector3(value, 6.5f, 0f);
            Instantiate(birdy,new Vector3(position.x,position.y,0f),Quaternion.identity);

            //increasing difficulty after every spawn
           

    }

   
  
}
}