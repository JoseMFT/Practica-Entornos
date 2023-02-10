using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IAEnemies: MonoBehaviour {
    public GameObject[] target;
    public int arrayPos = 0, score = 0;
    public float speed = 7.5f;
    public TextMeshProUGUI textoPuntos;
    Rigidbody rbEnemy;
    string scoreText;
    Vector3 destination;

    [SerializeField]
    GameObject dest1, dest2, dest3, dest4, dest5, dest6;

    private void Awake () {
        rbEnemy = gameObject.GetComponent<Rigidbody>();
        target = new GameObject[6] { dest1, dest2, dest3, dest4, dest5, dest6 };
    }
    void Start () {

        destination = target[arrayPos].transform.position;
    }

    // Update is called once per frame
    void Update () {

        if (Vector3.Distance (transform.position, destination) > 0.05f) {
            transform.LookAt (destination);
            transform.position = Vector3.MoveTowards (transform.position, destination, speed * Time.deltaTime);
        } else {
            if (arrayPos < target.Length - 1) {
                arrayPos++;
                destination = target[arrayPos].transform.position;
            } else {
                arrayPos = 0;
                destination = target[arrayPos].transform.position;
            }
        }
    }

    void OnCollisionEnter (Collision choque) {
        rbEnemy.constraints = RigidbodyConstraints.FreezeAll;
        rbEnemy.constraints = RigidbodyConstraints.None;
    }

    void OnTriggerEnter (Collider collision) {
        if (collision.gameObject.tag == "Laser") {
            int.TryParse (textoPuntos.text, out score);
            score++;
            textoPuntos.text = score.ToString ();
            Destroy (gameObject);
        }
    }
}
