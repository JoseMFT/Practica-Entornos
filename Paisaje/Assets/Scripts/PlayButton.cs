using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    Vector3 ogSize;
    void Start()
    {
        ogSize = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScaleUp () {
        LeanTween.scale (gameObject, ogSize * 1.1f, .1f).setEaseOutCubic ();
    }

    public void ScaleDown() {
        LeanTween.scale (gameObject, ogSize, .1f).setEaseInCubic ();
    }

    public void ChangeScene() {
        SceneManager.LoadScene (1);
    }
}
