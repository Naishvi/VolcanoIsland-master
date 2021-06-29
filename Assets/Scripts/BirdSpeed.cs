
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy Class.
/// Contains movement and collision detection for the spawned enemy gameobjects.
/// </summary>
[RequireComponent(typeof(Collider))]
public class BirdSpeed : MonoBehaviour
{

    private float speed;

    void Start()
    {
        //pick random value between min and max speed
        speed = 5.0f;

    }

    void Update()
    {
        //translate this object down at speed
        this.transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    ///
    private void OnTriggerEnter2D(Collider2D collision)
    {


     
    }
}
