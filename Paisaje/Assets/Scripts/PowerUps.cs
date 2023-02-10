using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps: MonoBehaviour {
    public GameObject[] target;
    int arrayPos;
    public GameObject powerUpPrefab, currentPowerUp;
    [SerializeField]
    GameObject dest1, dest2, dest3, dest4, dest5, dest6;
    public float powerUpSpawnTime = 40f, spawnTimeReference;
    public static PowerUps controlPowerUps;


    private void Awake () {
        target = new GameObject[6] { dest1, dest2, dest3, dest4, dest5, dest6 };
    }
    void Start () {
        spawnTimeReference = powerUpSpawnTime;
    }

    // Update is called once per frame
    void Update () {
        if (powerUpSpawnTime > 0) {
            powerUpSpawnTime -= Time.deltaTime;
        } else {
            if (currentPowerUp != null) {
                Destroy (currentPowerUp);
            }
            powerUpSpawnTime = spawnTimeReference;
            currentPowerUp = Instantiate (powerUpPrefab, target[Randomize (arrayPos)].transform.position, Quaternion.identity);
        }
    }
    private void OnTriggerEnter (Collider other) {
        if (other.gameObject.tag == "PowerUp") {
            powerUpSpawnTime = 0;
        }
    }

    public int Randomize (int x) {
        int y = x;
        while (y == x) {
            x = (int) Mathf.Floor (Random.Range (0f, 6f));
        }
        return x;
    }
}
