using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lv2 : MonoBehaviour
{
    public Image img;
    public Sprite[] test;

    public void Bang()
    {
        int random_dreams = Random.Range(0, test.Length);

        img.sprite = test[random_dreams];
    }
}

