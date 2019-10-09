using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class Statistics : MonoBehaviour
{
    public CRUDScores dbClass;
    public Text easyPRchap1;
    public Text easyPRchap2;
    public Text easyPRchap3;
    public Text easyPRchap4;
    public Text midPRchap1;
    public Text midPRchap2;
    public Text midPRchap3;
    public Text midPRchap4;
    public Text hardPRchap1;
    public Text hardPRchap2;
    public Text hardPRchap3;
    public Text hardPRchap4;
    public Text easyTAchap1;
    public Text easyTAchap2;
    public Text easyTAchap3;
    public Text easyTAchap4;
    public Text midTAchap1;
    public Text midTAchap2;
    public Text midTAchap3;
    public Text midTAchap4;
    public Text hardTAchap1;
    public Text hardTAchap2;
    public Text hardTAchap3;
    public Text hardTAchap4;

    public void DropdownValueChanged(Dropdown Dropdown) {
        Debug.Log(Dropdown.options[Dropdown.value].text);
        string world = "";
        switch(Dropdown.options[Dropdown.value].text){
            case "World 1": world =  "world1"; break;
            case "World 2": world =  "world2"; break;
            case "World 3": world =  "world3"; break;
            case "World 4": world =  "world4"; break;  
        }
        dbClass.getStatistics(world);
    }

    void Awake() {
        dbClass.getStatistics("world1");
    }

    void Update(){
        double tmpPR;
        dbClass.passingRateDict.TryGetValue("chap1easy",out tmpPR);
        easyPRchap1.text = tmpPR.ToString();
        dbClass.passingRateDict.TryGetValue("chap2easy",out tmpPR);
        easyPRchap2.text = tmpPR.ToString();
        dbClass.passingRateDict.TryGetValue("chap3easy",out tmpPR);
        easyPRchap3.text = tmpPR.ToString();
        dbClass.passingRateDict.TryGetValue("chap4easy",out tmpPR);
        easyPRchap4.text = tmpPR.ToString(); 
        dbClass.passingRateDict.TryGetValue("chap1mid",out tmpPR);
        midPRchap1.text = tmpPR.ToString();
        dbClass.passingRateDict.TryGetValue("chap2mid",out tmpPR);
        midPRchap2.text = tmpPR.ToString();
        dbClass.passingRateDict.TryGetValue("chap3mid",out tmpPR);
        midPRchap3.text = tmpPR.ToString();
        dbClass.passingRateDict.TryGetValue("chap4mid",out tmpPR);
        midPRchap4.text = tmpPR.ToString();
        dbClass.passingRateDict.TryGetValue("chap1hard",out tmpPR);
        hardPRchap1.text = tmpPR.ToString();
        dbClass.passingRateDict.TryGetValue("chap2hard",out tmpPR);
        hardPRchap2.text = tmpPR.ToString();
        dbClass.passingRateDict.TryGetValue("chap3hard",out tmpPR);
        hardPRchap3.text = tmpPR.ToString();
        dbClass.passingRateDict.TryGetValue("chap4hard",out tmpPR);
        hardPRchap4.text = tmpPR.ToString();  

        int tmpTA;
        dbClass.totalAttemptDict.TryGetValue("chap1easy",out tmpTA);
        easyTAchap1.text = tmpTA.ToString();
        dbClass.totalAttemptDict.TryGetValue("chap2easy",out tmpTA);
        easyTAchap2.text = tmpTA.ToString();
        dbClass.totalAttemptDict.TryGetValue("chap3easy",out tmpTA);
        easyTAchap3.text = tmpTA.ToString();
        dbClass.totalAttemptDict.TryGetValue("chap4easy",out tmpTA);
        easyTAchap4.text = tmpTA.ToString(); 
        dbClass.totalAttemptDict.TryGetValue("chap1mid",out tmpTA);
        midTAchap1.text = tmpTA.ToString();
        dbClass.totalAttemptDict.TryGetValue("chap2mid",out tmpTA);
        midTAchap2.text = tmpTA.ToString();
        dbClass.totalAttemptDict.TryGetValue("chap3mid",out tmpTA);
        midTAchap3.text = tmpTA.ToString();
        dbClass.totalAttemptDict.TryGetValue("chap4mid",out tmpTA);
        midTAchap4.text = tmpTA.ToString();
        dbClass.totalAttemptDict.TryGetValue("chap1hard",out tmpTA);
        hardTAchap1.text = tmpTA.ToString();
        dbClass.totalAttemptDict.TryGetValue("chap2hard",out tmpTA);
        hardTAchap2.text = tmpTA.ToString();
        dbClass.totalAttemptDict.TryGetValue("chap3hard",out tmpTA);
        hardTAchap3.text = tmpTA.ToString();
        dbClass.totalAttemptDict.TryGetValue("chap4hard",out tmpTA);
        hardTAchap4.text = tmpTA.ToString();                         
        
    }
        
    public void BackToProfMode()
    {
        Application.LoadLevel("ProfMode");
        
    }
}
