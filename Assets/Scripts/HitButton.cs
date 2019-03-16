using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitButton : MonoBehaviour {

    public Transform wallTransform;
    public Transform targetTransform;
    public float health = 10f;
    public float transformChange = 50f;
	// Use this for initialization
	void Start () {
        targetTransform.GetComponent<Transform>();
        wallTransform.GetComponent<Transform>();
	}
	
    public void TakeDamage(float amount) {
        health -= amount;
        if(health <= 0f) {
            health = 2f;
            transformChange += 30f;

        }
    }


}
