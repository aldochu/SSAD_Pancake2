using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    // Start is called before the first frame update
    public Text CharName;
    public Text CharDesc;
    public GameObject elf;
    public GameObject space;
    public GameObject bat;
    int character;
    void Start()
    {
        Time.timeScale = 1;
        character = 1;
        updateCharacter();
    }
    public void goLeft()
    {
        Debug.Log("going left");
        if (character==1)
        {
            character = 3;
        }
        else
        {
            character--;
        }
        updateCharacter();
    }
    public void goRight()
    {
        Debug.Log("going right");
        
        if (character == 3)
        {
            character = 1;
        }
        else
        {
            character++;
        }
        updateCharacter();
    }
    void updateCharacter()
    {
        if (character==1)
        {
            elf.SetActive(true);
            space.SetActive(false);
            bat.SetActive(false);
            CharName.text = "Mr Pancake";
            CharDesc.text = "Mr Pancake is a happy elf from the kingdom of happy land";
        }
        else if (character==2)
        {
            elf.SetActive(false);
            space.SetActive(true);
            bat.SetActive(false);
            CharName.text = "Spaceman";
            CharDesc.text = "Spaceman is an astronaut who loves ice cream";
        }
        else if (character==3)
        {
            elf.SetActive(false);
            space.SetActive(false);
            bat.SetActive(true);
            CharName.text = "Coward, The Brave Bat";
            CharDesc.text = "Coward is a bat who's afraid of the dark";
        }
        StaticVariable.characterSelect = character;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
