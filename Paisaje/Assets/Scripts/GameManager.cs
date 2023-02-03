using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour {
    public static GameManager gameController;
    public int numberOfShips = 4;
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (numberOfShips <= 0) {
            FinishGame ();
        }
    }

    public void FinishGame () {

    }
}
