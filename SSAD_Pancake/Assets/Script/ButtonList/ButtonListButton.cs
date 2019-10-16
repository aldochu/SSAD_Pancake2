using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListButton : MonoBehaviour
{
    [SerializeField]
    private Text myText;

    [SerializeField]
    private ButtonListControl buttonControl;

    private string questionId;

    public void SetText(string textString, string questionId)
    {
        myText.text = textString;
        this.questionId = questionId;

    }

    public void OnClick()
    {
        buttonControl.ButtonClicked(questionId);
    }
}
