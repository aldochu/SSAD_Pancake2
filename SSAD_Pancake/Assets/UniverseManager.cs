using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UniverseManager : MonoBehaviour
{
	public Button world1, world2;
	// Start is called before the first frame update
	void Start()
    {
		world1.image.alphaHitTestMinimumThreshold = 0.5f;
		world2.image.alphaHitTestMinimumThreshold = 0.5f;
		world1.interactable = true;
		world2.interactable = true;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}

