using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ModifyChapter : MonoBehaviour
{

    // needed to store value of the input fields from the scene "EditQAndA"
    public Dropdown dropdown;
    public InputField question;
    public InputField a1, a2, a3, a4;
    string questionValue;
    string valueA1, valueA2, valueA3, valueA4;

    // Start is called before the first frame update
    void Start()
    {

        //TODO: Connection to DB

        //gets current Value of InputField
        questionValue = PlayerPrefs.GetString("InputQuestion");
        valueA1 = PlayerPrefs.GetString("InputAnswer1");
        valueA2 = PlayerPrefs.GetString("InputAnswer2");
        valueA3 = PlayerPrefs.GetString("InputAnswer3");
        valueA4 = PlayerPrefs.GetString("InputAnswer4");

        question.text = questionValue;
        a1.text = valueA1;
        a2.text = valueA2;
        a3.text = valueA3;
        a4.text = valueA4;

        // calls method difficultyDropdown
        difficultyDropdown();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //change scene
    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void changeChapter(int chapter)
    {
        QuestionData.chapter = chapter;
    }

    //going a page back
    public void goBack(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // dropdown for the difficulty of the question in the scene "EditQandA"
    public void difficultyDropdown()
    {
        List<string> difficulty = new List<string>() { "1", "2", "3", "4" };
        dropdown.AddOptions(difficulty);
    }

    //saves the typed-in value to the InputField in the scene "EditQandA"
    public void saveInput()
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

}
