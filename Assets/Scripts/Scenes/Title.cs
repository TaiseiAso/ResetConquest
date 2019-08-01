using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour {

    public GameObject canvasObject; // canvas object

    void Awake() {
        GameObject blackArrowPrefab = (GameObject)Resources.Load("Prefabs/Others/BlackArrow");
        GameObject grayArrowPrefab = (GameObject)Resources.Load("Prefabs/Others/GrayArrow");
        GameObject blueArrowPrefab = (GameObject)Resources.Load("Prefabs/Others/BlueArrow");

        for (int i = 0; i < 9; i ++) {
            GameObject blueArrow = (GameObject)Instantiate(blueArrowPrefab);
            Arrow arrow = blueArrow.GetComponent<Arrow>();
            arrow.Set(i*100 - 50, 650, 700, i*1.2, 10.8);
            blueArrow.transform.SetParent(canvasObject.transform);
            blueArrow.transform.SetAsLastSibling();
        }

        for (int i = 0; i < 8; i ++) {
            GameObject grayArrow = (GameObject)Instantiate(grayArrowPrefab);
            Arrow arrow = grayArrow.GetComponent<Arrow>();
            arrow.Set(i*100, 650, 700, i*0.8, 6.4);
            grayArrow.transform.SetParent(canvasObject.transform);
            grayArrow.transform.SetAsLastSibling();
        }

        for (int i = 0; i < 9; i ++) {
            GameObject blackArrow = (GameObject)Instantiate(blackArrowPrefab);
            Arrow arrow = blackArrow.GetComponent<Arrow>();
            arrow.Set(i*100 - 50, 650, 700, i*0.4, 3.6);
            blackArrow.transform.SetParent(canvasObject.transform);
            blackArrow.transform.SetAsLastSibling();
        }
    }

    void Start() {

    }

    void Update() {

    }
}
