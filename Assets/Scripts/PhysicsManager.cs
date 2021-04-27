using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsManager : MonoBehaviour
{
    public GameObject pyramid;
    public GameObject menu;
    private Vector3 scaleChange, positionChange;
    // Start is called before the first frame update
    void Start()
    {
        pyramid = GameObject.Find("pyramid");
        scaleChange = new Vector3(1.0f, 1.0f, 1.0f);
        positionChange = new Vector3(0.0f, 0.005f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            iTween.MoveTo(pyramid, iTween.Hash("x", menu.transform.position.x, "y", menu.transform.position.y-0.3, "z", menu.transform.position.z));
        }
        //Roll
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            iTween.RotateBy(pyramid, iTween.Hash("x", 1));
        }
        //Yaw
        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            iTween.RotateBy(pyramid, iTween.Hash("y", 1));
        }
        //Pitch
        if (Input.GetKeyDown(KeyCode.KeypadMultiply))
        {
            iTween.RotateBy(pyramid, iTween.Hash("z", 1));
        }
        //Enlarge
        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            pyramid.transform.localScale += scaleChange;

        }
        //Shrink
        if (Input.GetKey(KeyCode.KeypadMinus))
        {
            pyramid.transform.localScale -= scaleChange;
        }
    }
}
