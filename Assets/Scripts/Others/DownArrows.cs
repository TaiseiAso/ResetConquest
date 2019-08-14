using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownArrows : MonoBehaviour {

    void Awake() {
        GameObject blackArrowPrefab = (GameObject)Resources.Load("Prefabs/Others/BlackArrow");
        GameObject grayArrowPrefab = (GameObject)Resources.Load("Prefabs/Others/GrayArrow");
        GameObject blueArrowPrefab = (GameObject)Resources.Load("Prefabs/Others/BlueArrow");

        for (int i = 0; i < 9; i ++) {
            GameObject blueArrowObject = (GameObject)Instantiate(blueArrowPrefab);
            UpDown arrow = blueArrowObject.GetComponent<UpDown>();
            arrow.Set(i*100 - 50, 50, 100, i*1.2, 10.8);
            blueArrowObject.transform.SetParent(transform);
        }

        for (int i = 0; i < 8; i ++) {
            GameObject grayArrowObject = (GameObject)Instantiate(grayArrowPrefab);
            UpDown arrow = grayArrowObject.GetComponent<UpDown>();
            arrow.Set(i*100, 50, 100, i*0.8, 6.4);
            grayArrowObject.transform.SetParent(transform);
        }

        for (int i = 0; i < 9; i ++) {
            GameObject blackArrowObject = (GameObject)Instantiate(blackArrowPrefab);
            UpDown arrow = blackArrowObject.GetComponent<UpDown>();
            arrow.Set(i*100 - 50, 50, 100, i*0.4, 3.6);
            blackArrowObject.transform.SetParent(transform);
        }
    }
}
