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
    public InputField a1, a2, a3, a4, correctAns;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            GameObject.Find("InputQuestion").GetComponent<InputField>().text = PlayerPrefs.GetString("qn");
            GameObject.Find("InputAnswer1").GetComponent<InputField>().text = PlayerPrefs.GetString("a1");
            GameObject.Find("InputAnswer2").GetComponent<InputField>().text = PlayerPrefs.GetString("a2");
            GameObject.Find("InputAnswer3").GetComponent<InputField>().text = PlayerPrefs.GetString("a3");
            GameObject.Find("InputAnswer4").GetComponent<InputField>().text = PlayerPrefs.GetString("a4");
            GameObject.Find("CorrectAnswer").GetComponent<InputField>().text = PlayerPrefs.GetString("ca");
            GameObject.Find("DifficultyDropdown").GetComponent<Dropdown>().value = PlayerPrefs.GetString("difficulty") == "easy" ? 0 : PlayerPrefs.GetString("difficulty") == "medium" ? 1 : 2;
        } catch { }

    }

    //change scene
    public void changeScene(string sceneName, string world, string chap, string difficulty, GetQuestion questionObj)
    {
        PlayerPrefs.SetString("qn", questionObj.question.question);
        PlayerPrefs.SetString("a1", questionObj.question.ans1);
        PlayerPrefs.SetString("a2", questionObj.question.ans2);
        PlayerPrefs.SetString("a3", questionObj.question.ans3);
        PlayerPrefs.SetString("a4", questionObj.question.ans4);
        PlayerPrefs.SetString("ca", questionObj.question.correctAns);
        PlayerPrefs.SetString("difficulty", difficulty);

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

}
