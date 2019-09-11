using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleFunction : MonoBehaviour
{
    public float speed;
    private int direction;
    public float maxRotation = 45f;
    // Start is called before the first frame update
    public string sceneName;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //transform.Rotate.(0, 0,speed * direction, Space.Self);

        transform.rotation = Quaternion.Euler(0f, 0f, maxRotation * Mathf.Sin(Time.time * speed));
    }

    void OnMouseDown()
    {
        //Destroy(gameObject);
        Application.LoadLevel(sceneName);
    }
}

