using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class universeLogic : MonoBehaviour
{
	public Button world1, world2;

	// Start is called before the first frame update
	void Start()
    {
		world1.interactable = true;
		world2.interactable = true;
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
