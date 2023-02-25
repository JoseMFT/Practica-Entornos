using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton: MonoBehaviour {
    Vector3 ogSize;
    public GameObject canvas;
    public CanvasGroup transitionCanvas;
    void Start () {
        ogSize = transform.localScale;
    }

    // Update is called once per frame
    void Update () {

    }

    public void ScaleUp () {
        LeanTween.scale (gameObject, ogSize * 1.1f, .1f).setEaseOutCubic ();
    }

    public void ScaleDown () {
        LeanTween.scale (gameObject, ogSize, .1f).setEaseInCubic ();
    }

    public void ChangeScene () {
        canvas.SetActive (true);
        LeanTween.alphaCanvas (transitionCanvas, 0f, 0f).setOnComplete (() => {
            LeanTween.alphaCanvas (transitionCanvas, 1f, 2f).setOnComplete (() => {
                SceneManager.LoadScene (1);
            });
        });
    }

    public void ExitGame () {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit ();
    }
}
