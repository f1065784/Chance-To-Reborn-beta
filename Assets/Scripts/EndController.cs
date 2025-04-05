using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndController : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("enteredToEndRoom", 1);
        Debug.Log("End:" + PlayerPrefs.GetInt("enteredToEndRoom"));
    }
}
