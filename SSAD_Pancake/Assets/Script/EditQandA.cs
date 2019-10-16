using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class EditQandA : MonoBehaviour
{
        [SerializeField]
    public CRUDquestion crudQuestion;
    public Dropdown dropdown;
    public InputField question;
    public InputField a1, a2, a3, a4;
    string questionValue;
    string valueA1, valueA2, valueA3, valueA4;


    
    void Start()
    {
        //TODO: Connection to DB
        Debug.Log("HIIIII");
        //gets current Value of InputField
        questionValue = PlayerPrefs.GetString("InputQuestion");
        valueA1 = PlayerPrefs.GetString("InputAnswer1");
        valueA2 = PlayerPrefs.GetString("InputAnswer2");
        valueA3 = PlayerPrefs.GetString("InputAnswer3");
        valueA4 = PlayerPrefs.GetString("InputAnswer4");

        Debug.Log("*** "+PlayerPrefs.GetString("world"));

        GameObject.Find("InputQuestion").GetComponent<InputField>().text = PlayerPrefs.GetString("world");

        question.text = questionValue;
        a1.text = valueA1;
        a2.text = valueA2;
        a3.text = valueA3;
        a4.text = valueA4;

     
        difficultyDropdown();
    }

    // dropdown for the difficulty of the question
    public void difficultyDropdown()
    {
        List<string> difficulty = new List<string>() { "1", "2", "3", "4" };
        dropdown.AddOptions(difficulty);
    }

    //saves the typed-in value to the InputField
    public void save()
    {
        questionValue = question.text;
        valueA1 = a1.text;
        valueA2 = a2.text;
        valueA3 = a3.text;
        valueA4 = a4.text;
        PlayerPrefs.SetString("InputQuestion", questionValue);
        PlayerPrefs.SetString("InputAnswer1", valueA1);
        PlayerPrefs.SetString("InputAnswer2", valueA2);
        PlayerPrefs.SetString("InputAnswer3", valueA3);
        PlayerPrefs.SetString("InputAnswer4", valueA4);

    }

    public void backButton()
    {
        SceneManager.LoadScene("QuestionOverview");
    }

}
