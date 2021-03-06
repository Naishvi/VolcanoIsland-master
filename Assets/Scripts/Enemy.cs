/*
Copyright 2020 Micah Schuster

Redistribution and use in source and binary forms, with or without modification,
are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice, this
list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice,
this list of conditions and the following disclaimer in the documentation and/or
other materials provided with the distribution.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT,
INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE
OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy Class.
/// Contains movement and collision detection for the spawned enemy gameobjects.
/// </summary>
[RequireComponent(typeof(Collider))]
public class Enemy : MonoBehaviour
{

    //reference to the player script
    //Do we really need the enemy to know about the Player?
    //Depending on the situation, maybe or maybe not.
    /// <summary>
    /// Reference to the gameobject that contains Player
    /// </summary>
    Player p;

    /// <summary>
    /// Amount of damage that the enemy does to the player
    /// </summary>
    public int damage;

    /// <summary>
    /// Minimum possible speed for Enemy movement.
    /// </summary>
    public float minSpeed;

    /// <summary>
    /// Maximum possible speed for Enemy movement.
    /// </summary>
    public float maxSpeed;

    /// <summary>
    /// Chosen speed for this object.
    /// </summary>
    private float speed;

    /// <summary>
    /// GameObject (Prefab) that contains the death particle effect.
    /// </summary>
    public GameObject deathEffect;

    /// <summary>
    /// GameObject (Prefab) that contains the death particle effect.
    /// </summary>
    public GameObject hitEffect;

    /// <summary>
    /// Sets a random speed and gets reference to the player gameobject.
    /// </summary>
    void Start()
    {
        //pick random value between min and max speed
        speed = Random.Range(minSpeed, maxSpeed);

        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        this.transform.rotation = Quaternion.Euler(0,0,getRotation(transform.position));
    }

    /// <summary>
    /// Updates the gameobject position over time.
    /// </summary>
    void Update()
    {
        //translate this object down at speed
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    /// <summary>
    /// Unity collision check. When the rigidbody eneters a trigger it checks for
    /// if the collider is the player or the ground. Applies appropriate damage
    /// and/or instantiates particle effects.
    /// </summary>
    /// <param name="collision">Collider that was triggered.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //reduce player health
            p.takeDamage(damage);
            Instantiate(hitEffect, new Vector3(transform.position.x, transform.position.y - 0.3f, -0.3f), Quaternion.identity);
            GameObject.Destroy(gameObject);
        }

        //destroy enemy if hits the ground
        if (collision.tag == "Ground")
        {
            Instantiate(deathEffect, new Vector3(transform.position.x, transform.position.y - 0.5f, -0.3f), Quaternion.identity);
            GameObject.Destroy(gameObject);
        }
    }

    // Calculates the angle needed to get to the player's expected position
    public float getRotation(Vector3 pos)
    {
        Vector3 expectedPos = p.expectedPosition();
        float direction = Mathf.Rad2Deg * Mathf.Atan2(pos.y - expectedPos.y, pos.x - expectedPos.x);
        direction = -(90 - direction);

        return Mathf.Clamp(direction, -30, 30);
    }
}
