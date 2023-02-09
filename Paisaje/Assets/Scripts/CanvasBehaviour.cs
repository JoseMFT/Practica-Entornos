using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasBehaviour: MonoBehaviour {
    public TextMeshProUGUI speedOMeter;
    public Slider OverHeat;
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        speedOMeter.text = (SpaceshipMov1.valoresCanvas.speed * 20f).ToString (".00");
    }
}
