using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpaceshipMov1: MonoBehaviour {
    public static SpaceshipMov1 valoresCanvas;
    public TextMeshProUGUI speedOMeter;
    public Slider OverHeat, powerUpUI;
    public float speed = 15f, rotationHor = 50f, rotationVer = 30f, rotationSensitivity = 1f, shootCD = .75f, cdReduction = .5f, cdReference = .75f;
    public float rotationShipX, rotationShipY, rotationShipZ, powerUpDuration = 15f, powerUpLifetimeReference;
    public GameObject laser, boostFX, powerUpSlider;
    public Rigidbody rigidBodyShip;
    public float shotsOverHeat = 0f;
    bool powerUpTimer = false;

    // Start is called before the first fr
    Vector3 prevRot, currentRot;

    private void Awake () {

    }
    void Start () {
        cdReference = shootCD;
        powerUpLifetimeReference = powerUpDuration;
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
            if (speed <= 22.5f) {
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
        } else {
            if (Input.GetKey ("space")) {
                if (shotsOverHeat < 1f) {
                    shotsOverHeat += .25f * cdReduction;
                    Instantiate (laser, transform.position, Quaternion.Euler (currentRot));
                    shootCD = cdReference * cdReduction;
                }
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

        if (powerUpTimer == true) {
            if (powerUpDuration > 0) {
                powerUpDuration -= Time.deltaTime;
                powerUpUI.value = powerUpDuration / powerUpLifetimeReference;
            } else {
                cdReduction = 1f;
                powerUpSlider.SetActive (false);
                powerUpDuration = powerUpLifetimeReference;
                powerUpTimer = false;
            }
        }
    }

    private void OnTriggerEnter (Collider other) {
        if (other.gameObject.tag == "PowerUp") {
            powerUpTimer = true;
            powerUpSlider.SetActive (true);
            powerUpUI.value = 1f;
            cdReduction = .5f;
        }
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
