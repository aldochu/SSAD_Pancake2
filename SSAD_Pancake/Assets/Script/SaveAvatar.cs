using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAvatar : MonoBehaviour
{
    CustomizeAvatar head;
    CustomizeAvatar headGear;
    CustomizeAvatar body;

    public AddUser AddUserInterface;

    // Start is called before the first frame update
    void Start()
    {

        head = GameObject.Find("HeadBtn").GetComponent<CustomizeAvatar>();
        headGear = GameObject.Find("HeadGearBtn").GetComponent<CustomizeAvatar>();
        body = GameObject.Find("BodyBtn").GetComponent<CustomizeAvatar>();

        AddUserInterface.getUserAvatar(headGear, head, body);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save()
    {
        int headGearIndex = headGear.GetIndex();
        int headIndex = head.GetIndex();
        int bodyIndex = body.GetIndex();
        AddUserInterface.updateAvatar("" + headGearIndex,
            "" + headIndex,
            "" + bodyIndex);
    }
}
