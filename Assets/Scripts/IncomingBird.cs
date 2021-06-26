using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomingBird : MonoBehaviour
{
    public GameObject birdPrefab; 
    public float respawnTime = 1.0f; 

    private Vector2 screenBounds; 
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(birdWave());
    }
    private void spawnBird()
    {
        GameObject birdy = Instantiate(birdPrefab) as GameObject; 
        birdy.transform.position = new Vector2(screenBounds.x * -2, Random.Range(-screenBounds.y, screenBounds.y)); 
    }

    IEnumerator birdWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnBird();
        }
    }

    
}
