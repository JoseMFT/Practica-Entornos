using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour {
    public TextMeshProUGUI textoPuntos;
    public int score = 0;

    public static GameManager gameController;
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        int.TryParse (textoPuntos.text, out score);
        if (score >= 5) { 
            FinishGame ();
        }
    }

    public void FinishGame () {
        SceneManager.LoadScene (0);
    }
}
