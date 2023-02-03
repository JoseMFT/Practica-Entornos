using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth: MonoBehaviour {
    public static EnemyHealth health;
    public float shipHP = 100f;
    public GameObject explosionFX;
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (shipHP <= 0) {
            Instantiate (explosionFX, transform.position, Quaternion.identity);
            GameManager.gameController.numberOfShips--;
            Destroy (gameObject);
        }
    }
}
