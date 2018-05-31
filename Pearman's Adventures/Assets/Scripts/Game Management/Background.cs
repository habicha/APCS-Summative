﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Background : MonoBehaviour {

    public Transform target;
    private SpawnObjects spawnObjects;

	// Use this for initialization
	void Start () {
        spawnObjects = Camera.main.GetComponent<SpawnObjects>();
        if (spawnObjects == null)
            throw new NullReferenceException("Main camera must contain a SpawnObjects script.");

        
	}

    // Update is called once per frame
    void Update()
    {
        float step = Toolbox.Instance.ScrollSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target.position, step);

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            transform.position = Vector2.zero;
            spawnObjects.Spawn();
        }
    }
}