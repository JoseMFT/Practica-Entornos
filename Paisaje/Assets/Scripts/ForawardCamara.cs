using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForawardCamara: MonoBehaviour {
    public float speed = 3.5f;
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        transform.position += transform.forward * Time.deltaTime * speed;
    }
}
