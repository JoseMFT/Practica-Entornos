using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEnemies: MonoBehaviour {
    public GameObject[] target;
    public int arrayPos = 0;
    public float speed = 5f;
    Vector3 destination;

    [SerializeField]
    GameObject dest1, dest2, dest3, dest4, dest5, dest6;

    private void Awake () {
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
}
