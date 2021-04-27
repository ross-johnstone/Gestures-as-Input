using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public Material[] MyMaterials;
    private int arrayPos;
    public MeshRenderer my_renderer;

    private void Start()
    {
        MeshRenderer my_renderer = GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad6) && MyMaterials.Length > 0)
        {
            arrayPos++;
            arrayPos %= MyMaterials.Length;
            my_renderer.material = MyMaterials[arrayPos];
        }
    }
}
