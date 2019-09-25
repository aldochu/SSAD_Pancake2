using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsTransformer : MonoBehaviour {

    private Transform dataContainer;

    private void Awake(){
        dataContainer = transform.Find("dataContainer");
    }

    void Start()
    {

    }
    public void BackToProfMode()
    {
        Application.LoadLevel("ProfMode");
        
    }
}