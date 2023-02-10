using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour {
    public TextMeshProUGUI textoPuntos;
    public int score = 0;
    public GameObject canvas;
    public CanvasGroup transitionCanvas;
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
        canvas.SetActive (true);
        LeanTween.alphaCanvas (transitionCanvas, 0f, 0f).setOnComplete (() => {
            LeanTween.alphaCanvas (transitionCanvas, 1f, 2f).setOnComplete (() => {
                SceneManager.LoadScene (0);
            });
        });
    }
}
