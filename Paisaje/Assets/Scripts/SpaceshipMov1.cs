using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpaceshipMov1: MonoBehaviour {
    public static SpaceshipMov1 valoresCanvas;
    public TextMeshProUGUI speedOMeter;
    public Slider OverHeat;
    public float speed = 15f, rotationHor = 50f, rotationVer = 30f, rotationSensitivity = 1f, shootCD = .25f;
    public float rotationShipX, rotationShipY, rotationShipZ;
    public GameObject laser, boostFX;
    public Rigidbody rigidBodyShip;
    public float shotsOverHeat = 0f;

    // Start is called before the first fr
    Vector3 prevRot, currentRot;
    void Start () {
        rigidBodyShip = gameObject.GetComponent<Rigidbody> ();
        currentRot = transform.position;
    }

    // Update is called once per frame
    void Update () {
        if (shotsOverHeat > 0f) {
            shotsOverHeat -= .1f * Time.deltaTime;
        }
        currentRot = transform.rotation.eulerAngles;
        rotationShipX = Input.GetAxis ("Vertical") * rotationVer * Time.deltaTime;
        rotationShipY = Input.GetAxis ("Horizontal") * rotationHor * Time.deltaTime;

        if (Input.GetKey ("q")) {
            rotationShipZ = rotationSensitivity * rotationHor * .75f * Time.deltaTime;
        } else if (Input.GetKey ("e")) {
            rotationShipZ = -rotationSensitivity * rotationHor * .75f * Time.deltaTime;
        }

        if (!Input.GetKey ("q") && !Input.GetKey ("e") && prevRot.x != currentRot.x) {
            ResetRigidBody ();
        }

        if (AbsCalculator (Input.GetAxis ("Vertical")) <= 0.0001f && AbsCalculator (Input.GetAxis ("Horizontal")) >= -.001f && prevRot.z != currentRot.x) {
            ResetRigidBody ();
        }

        if (AbsCalculator (Input.GetAxis ("Horizontal")) <= 0.0001f && AbsCalculator (Input.GetAxis ("Horizontal")) <= 0.0001f && prevRot.y != currentRot.y) {
            ResetRigidBody ();
        }

        if (Input.GetKey ("left shift")) {
            if (speed != 22.5 || speed !> 22.5f) {
                speed += .65f * Time.deltaTime;
            }
            Instantiate (boostFX, transform.position, Quaternion.identity);

        } else if (!Input.GetKey ("left shift") && speed != 15f) {
            speed -= .85f * Time.deltaTime;
            if (speed < 15f) {
                speed = 15f;
            }
        }

        if (shootCD > 0) {
            shootCD -= Time.deltaTime;
        } else if (Input.GetKey ("space")) {
            if (shotsOverHeat < 1f) {
                shotsOverHeat += .1f;
                Instantiate (laser, transform.position, Quaternion.Euler (currentRot));
                shootCD = .25f;
            }
        }

        prevRot = currentRot;


        transform.position += transform.forward * speed * Time.deltaTime;

        transform.Rotate (new Vector3 (rotationShipX / 3f, rotationShipY / 4f, rotationShipZ / 5f) * speed, Space.Self);
        rotationShipX = 0f;
        rotationShipZ = 0f;
        rotationShipY = 0f;


        speedOMeter.text = (speed * 20f).ToString (".00") + " Km/h";
        OverHeat.value = shotsOverHeat;
    }

    public float AbsCalculator (float x) {
        float y = Mathf.Abs (x);
        return y;
    }

    public void ResetRigidBody () {
        rigidBodyShip.constraints = RigidbodyConstraints.FreezeAll;
        rigidBodyShip.constraints = RigidbodyConstraints.None;
    }
}
