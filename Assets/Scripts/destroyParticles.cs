using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyParticles : MonoBehaviour {

    private ParticleSystem thisSystem;

	// Use this for initialization
	void Start () {
        thisSystem = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!thisSystem.isPlaying)
        {
            Destroy(gameObject);
        }
	}
}
