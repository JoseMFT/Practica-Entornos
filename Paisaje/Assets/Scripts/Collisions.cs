using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions: MonoBehaviour {
    public GameObject waterFX, crashFX, earthFX;
    Vector3 contacPos;

    // Update is called once per frame
    void Update () {

    }

    private void OnTriggerEnter (Collider other) {
        contacPos = other.ClosestPoint (transform.position);
        if (other.gameObject.tag == "Water") {
            Instantiate (waterFX, contacPos, Quaternion.identity);
        }
    }

    private void OnCollisionEnter (Collision collision) {
        contacPos = collision.contacts[0].point;
        if (collision.gameObject.tag == "Ship") {
            Instantiate (crashFX, contacPos, Quaternion.identity);
        } else if (collision.gameObject.tag == "Suelo") {
            Instantiate (earthFX, contacPos, Quaternion.identity);
        }
    }
}
