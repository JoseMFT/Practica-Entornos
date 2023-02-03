using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour: MonoBehaviour {
    public float lifetime = 4f, laserSpeed = 50f;
    public GameObject waterFX, soilFX, explosionFX, ship;
    Vector3 contacPos, initialRotation;
    // Start is called before the first frame update
    void Start () {
        initialRotation = new Vector3 (ship.transform.rotation.x, ship.transform.rotation.y, ship.transform.rotation.z);
    }

    // Update is called once per frame
    void Update () {
        if (compareRotation () == false) {
            transform.rotation = Quaternion.Euler (initialRotation);
        }
        if (lifetime <= 0) {
            Destroy (gameObject);
        } else {
            lifetime -= Time.deltaTime;
            transform.position += Vector3.right * Time.deltaTime * laserSpeed;
        }
    }

    private void OnCollisionEnter (Collision collision) {
        contacPos = collision.contacts[0].point;
        if (collision.gameObject.tag == "Ship") {
            Instantiate (explosionFX, contacPos, Quaternion.identity);
            EnemyHealth.health.shipHP -= 50f;
            Destroy (gameObject);
        } else if (collision.gameObject.tag == "Suelo") {
            Instantiate (soilFX, contacPos, Quaternion.identity);
            Destroy (gameObject);
        }
    }

    private void OnTriggerEnter (Collider other) {
        contacPos = other.ClosestPoint (transform.position);
        if (other.gameObject.tag == "Water") {
            Instantiate (waterFX, contacPos, Quaternion.identity);
            Destroy (gameObject);
        }
    }

    public bool compareRotation () {
        bool x;
        int y = 0;
        if (transform.rotation.x == initialRotation.x) {
            y++;
        }
        if (transform.rotation.y == initialRotation.y) {
            y++;
        }
        if (transform.rotation.z == initialRotation.z) {
            y++;
        }

        if (y == 3) {
            x = true;
        } else {
            x = false;
        }

        return x;
    }
}
