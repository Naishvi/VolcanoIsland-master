using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Health : MonoBehaviour
{
    Player player;
    public int healthIncrease;
    public float minSpeed;
    public float maxSpeed;
    private float speed;
    public GameObject deathEffect;

    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Player"){
            player.HealUp(healthIncrease);
            GameObject.Destroy(gameObject);
        }

        if(collision.tag == "Ground"){
            GameObject.Destroy(gameObject);
        }
    }
}
