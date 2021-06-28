using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    public Transform healing;
    public GameObject heart;
    public GameObject deathEffect;
    public GameObject hitEffect;

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.DownArrow) ) {
           SpawnHeart();
       }         
    }

    void SpawnHeart() {
        Quaternion spawn = Quaternion.Euler(0,0,0);
        Instantiate(heart, healing.position, spawn);
    }
}
