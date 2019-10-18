using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsHandler : MonoBehaviour
{
    public GameObject[] stars;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void starsAchieved()
    {
        stars[0].SetActive(true);
        stars[1].SetActive(true);
    }
}
