using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadQuestions : MonoBehaviour
{
    public GameObject questionBtnPrefab;
    public GameObject canvas;
    public int btnID;

    // Start is called before the first frame update
    void Start()
    {
        int chapter = QuestionData.chapter;
        Debug.Log("Chapter " + chapter);
        // Connecting to the database and fetching the questions with the chapter.
        // ...
        int[] questionIDs = new int[5];
        string[] questions = new string[5];

        for(int i = 0; i < questions.Length; i++)
        {
            GameObject btn = Instantiate(questionBtnPrefab) as GameObject;
            btn.transform.SetParent(canvas.transform, false);
            btn.transform.localScale = new Vector3(1, 1, 1);

            btn.GetComponentInChildren<UnityEngine.UI.Text>().text = questions[i];
            btnID = i;
            btn.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
            {
                GameObject.Find("SceneController").GetComponent<ModifyChapter>().changeScene("EditQandA");
                Debug.Log("Button " + btnID);
            });
        }
    }

    public int getBtnId()
    {
        return btnID;
    }
}
