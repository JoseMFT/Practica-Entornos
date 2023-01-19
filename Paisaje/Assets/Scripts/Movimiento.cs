using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento: MonoBehaviour {
    float speed = 5f, jumpForce = 5f;
    Rigidbody personaje;
    public bool onTerrain = false, walking = false, jumping = false;
    public GameObject respawnObj;
    public Animation animations;
    Quaternion cameraMov;
    public GameObject cameraPOV;

    // Start is called before the first frame update

    private void Awake () {
        personaje = gameObject.GetComponent<Rigidbody> ();
    }
    void Start () {
        SpawnCode ();
        //cameraPOV = GameObject.Find ("Main Camera");
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKey ("d")) {
            //personaje.AddForce (new Vector3 (speed * Time.deltaTime, 0f, 0f), ForceMode.Impulse);
            transform.position += transform.right * speed * Time.deltaTime;
        } else if (Input.GetKey ("s")) {
            //personaje.AddForce (new Vector3 (0f, 0f, -speed * Time.deltaTime), ForceMode.Impulse);
            transform.position -= transform.forward * speed * Time.deltaTime;
        } else if (Input.GetKey ("a")) {
            //personaje.AddForce (new Vector3 (-speed * Time.deltaTime, 0f, 0f), ForceMode.Impulse);
            transform.position -= transform.right * speed * Time.deltaTime;
        } else if (Input.GetKey ("w")) {
            //personaje.AddForce (new Vector3 (0f, 0f, speed * Time.deltaTime), ForceMode.Impulse);
            transform.position += transform.forward * speed * Time.deltaTime;
        } else if (Input.GetKey ("left shift")) {
            speed = 7.5f;
        }

        if (onTerrain == true) {
            if (Input.GetKey ("space")) {
                onTerrain = false;
                personaje.AddForce (new Vector3 (0f, jumpForce * Time.deltaTime, 0f), ForceMode.Impulse);
            }
        } else {

        }

        if (transform.up != Vector3.up) {
            gameObject.transform.rotation = Quaternion.Euler (Vector3.up.y - transform.rotation.x, 0f, Vector3.up.y - transform.rotation.z);
        }

        /*Ray camaraRayo;
        camaraRayo =*/
        cameraMov = cameraPOV.transform.rotation;
        transform.rotation = Quaternion.Euler (transform.rotation.x, cameraMov.eulerAngles.y, transform.rotation.z);
    }

    public void OnCollisionEnter (Collision collision) {
        if (collision.gameObject.tag == "Suelo") {
            onTerrain = true;
        }
    }

    public void SpawnCode () {
        gameObject.transform.rotation = Quaternion.Euler (Vector3.up.x, Vector3.up.y, Vector3.up.z);
        gameObject.transform.position = respawnObj.transform.position;
    }

    public float RadToDeg (float x) {
        x = (x / (2 * 3.14159f)) * 360;
        return x;
    }
}
