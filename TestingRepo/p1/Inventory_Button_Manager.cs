using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Button_Manager : MonoBehaviour {
    public Button b0, b1, b2, b3, b4, b5, b6, b7, b8, b9;

    // Use this for initialization
    void Start()
    {
        b0.onClick.AddListener(() => TaskOnClick(0));
        b1.onClick.AddListener(() => TaskOnClick(1));
        b2.onClick.AddListener(() => TaskOnClick(2));
        b3.onClick.AddListener(() => TaskOnClick(3));
        b4.onClick.AddListener(() => TaskOnClick(4));
        b5.onClick.AddListener(() => TaskOnClick(5));
        b6.onClick.AddListener(() => TaskOnClick(6));
        b7.onClick.AddListener(() => TaskOnClick(7));
        b8.onClick.AddListener(() => TaskOnClick(8));
        b9.onClick.AddListener(() => TaskOnClick(9));


    }

    void TaskOnClick(int num)
    {
        Debug.Log("You just clicked button " + num);
        Inventory.instance.ShowItem(num);
    }

}

