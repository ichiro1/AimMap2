﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRandomPosition : MonoBehaviour {
    public Transform targetTransform;
    private float targetSecondCount = 1;
    public GameObject Targets;

    private Quaternion targetRotation = Quaternion.Euler(90,0,0);

    private bool hasTargetSpawned = false;
	// Use this for initialization
	void Start () {
        targetTransform.GetComponent<Transform>();
        Targets.GetComponent<Transform>();


    }
    
    

    // Update is called once per frame
    void Update () {
		targetSecondCount += 1;

        if (targetSecondCount == 75)
        {
            
            Vector3 TargetNewPosition = new Vector3(Random.Range(-30f, 30f), Random.Range(3f, 8f), -96);
            Instantiate(Targets, TargetNewPosition, targetRotation);
            targetSecondCount = 1;
            hasTargetSpawned = true;
            Destroy(gameObject);
	}
    }
}
