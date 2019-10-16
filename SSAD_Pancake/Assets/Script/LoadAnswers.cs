using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadAnswers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int btnNumber = GetComponent<LoadQuestions>().getBtnId();
        Debug.Log("Button " + btnNumber);
    }
}
