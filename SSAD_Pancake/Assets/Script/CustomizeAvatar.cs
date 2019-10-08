using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizeAvatar : MonoBehaviour
{
    public SpriteRenderer part;

    public Sprite[] options;

    public int index;

    void Start()
    {
        
    }


    void Update()
    {
        part.sprite = options[index];
    }

    public void Swap()
    {
        index = (index + 1) % options.Length;
    }

    public int GetIndex()
    {
        return index;
    }

    public void SetIndex(string index)
    {
        Debug.Log("setting index  " + index.Replace("\"", string.Empty));
        this.index = System.Convert.ToInt32(index.Replace("\"", string.Empty));
    }

}
