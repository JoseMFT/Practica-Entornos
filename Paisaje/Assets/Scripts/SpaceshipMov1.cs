using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMov1: MonoBehaviour {
    public float speed = 15f, rotationHor = 50f, rotationVer = 30f, rotationSensitivity = 1f, shootCD = .25f;
    public float rotationShipX, rotationShipY, rotationShipZ;
    public GameObject laser, boostFX;
    // Start is called before the first fr
    Vector3 prevRot, currentRot;
    void Start () {
        currentRot = transform.position;
    }

    // Update is called once per frame
    void Update () {

        rotationShipZ = Input.GetAxis ("Vertical") * rotationVer * Time.deltaTime;
        rotationShipY = Input.GetAxis ("Horizontal") * rotationHor * Time.deltaTime;

        /*if (Input.GetKey ("q")) {
            rotationShipX = rotationSensitivity * rotationHor * .75f * Time.deltaTime;
        } else if (Input.GetKey ("e")) {
            rotationShipX = -rotationSensitivity * rotationHor * .75f * Time.deltaTime;
        }*/

        if (Input.GetKey ("left shift")) {
            if (speed != 22.5) {
                speed = 22.5f;
            }
            Instantiate (boostFX, transform.position, Quaternion.identity);

        } else if (!Input.GetKey ("left shift") && speed != 15f) {
            speed = 15f;
        }

        if (shootCD > 0) {
            shootCD -= Time.deltaTime;
        } else {
            if (Input.GetKey ("space")) {
                Instantiate (laser, transform.position, transform.rotation);
                shootCD = 1f;
            }
        }

        transform.position += transform.forward * speed * Time.deltaTime;

        transform.Rotate (new Vector3 (rotationShipZ / 3f, rotationShipY / 4f, rotationShipX / 5f) * speed, Space.Self);
        rotationShipX = 0f;
        rotationShipZ = 0f;
        rotationShipY = 0f;
    }
}
