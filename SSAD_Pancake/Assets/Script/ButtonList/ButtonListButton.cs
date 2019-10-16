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

    public void SetText(string textString)
    {
        myText.text = textString;
    }

    public void OnClick()
    {
        buttonControl.ButtonClicked(buttonId);
    }
}
