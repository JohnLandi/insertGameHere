﻿using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hello", gameObject);
        gameObject.SetActive(false);
    }
}