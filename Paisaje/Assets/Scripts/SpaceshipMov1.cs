using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMov1: MonoBehaviour {
    public float speed = 15f, rotationHor = 50f, rotationVer = 40f, rotationSensitivity = 1f;
    public float rotationShipX, rotationShipY, rotationShipZ;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        rotationShipZ = Input.GetAxis ("Vertical") * rotationVer * Time.deltaTime;
        rotationShipY = Input.GetAxis ("Horizontal") * rotationHor * Time.deltaTime;

        if (Input.GetKey ("q")) {
            rotationShipX = rotationSensitivity * rotationHor * .75f * Time.deltaTime;
        } else if (Input.GetKey ("e")) {
            rotationShipX = -rotationSensitivity * rotationHor * .75f * Time.deltaTime;
        }

        if (Input.GetKey (KeyCode.LeftShift)) {
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        transform.Rotate (new Vector3 (rotationShipZ / 3f, rotationShipY / 4f, rotationShipX / 5f) * speed, Space.Self);
        rotationShipX = 0f;
        rotationShipZ = 0f;
        rotationShipY = 0f;
    }
}
