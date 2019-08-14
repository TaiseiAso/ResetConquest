using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownArrows : MonoBehaviour {

    void Awake() {
        GameObject blackArrowPrefab = (GameObject)Resources.Load("Prefabs/Others/BlackArrow");
        GameObject grayArrowPrefab = (GameObject)Resources.Load("Prefabs/Others/GrayArrow");
        GameObject blueArrowPrefab = (GameObject)Resources.Load("Prefabs/Others/BlueArrow");

        for (int i = 0; i < 9; i ++) {
            GameObject blueArrow = (GameObject)Instantiate(blueArrowPrefab);
            UpDown arrow = blueArrow.GetComponent<UpDown>();
            arrow.Set(i*100 - 50, 50, 100, i*1.2, 10.8);
            blueArrow.transform.SetParent(transform);
        }

        for (int i = 0; i < 8; i ++) {
            GameObject grayArrow = (GameObject)Instantiate(grayArrowPrefab);
            UpDown arrow = grayArrow.GetComponent<UpDown>();
            arrow.Set(i*100, 50, 100, i*0.8, 6.4);
            grayArrow.transform.SetParent(transform);
        }

        for (int i = 0; i < 9; i ++) {
            GameObject blackArrow = (GameObject)Instantiate(blackArrowPrefab);
            UpDown arrow = blackArrow.GetComponent<UpDown>();
            arrow.Set(i*100 - 50, 50, 100, i*0.4, 3.6);
            blackArrow.transform.SetParent(transform);
        }
    }
}
