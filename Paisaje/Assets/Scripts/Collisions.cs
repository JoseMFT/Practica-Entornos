using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions: MonoBehaviour {
    public GameObject waterFX, crashFX, earthFX;
    Vector3 contacPos;
    public Rigidbody rigidBodyShip;
    // Update is called once per frame
    private void Start () {
        rigidBodyShip = gameObject.GetComponent<Rigidbody> ();
    }

    private void OnTriggerEnter (Collider other) {
        contacPos = other.ClosestPoint (transform.position);
        Debug.Log ("Hit Water");
        if (other.gameObject.tag == "Water") {
            Instantiate (waterFX, contacPos, transform.rotation);
        }
    }

    private void OnCollisionEnter (Collision collision) {
        Message ();
        ResetRB ();
        contacPos = collision.contacts[0].point;
        if (collision.gameObject.tag == "Ship") {
            Instantiate (crashFX, contacPos, Quaternion.identity);
        } else if (collision.gameObject.tag == "Suelo") {
            Instantiate (earthFX, contacPos, Quaternion.identity);
        }
    }

    public void Message () {
        Debug.Log ("Has colissioned");
    }

    public void ResetRB () {
        rigidBodyShip.constraints = RigidbodyConstraints.FreezeAll;
        rigidBodyShip.constraints = RigidbodyConstraints.None;
    }
}
