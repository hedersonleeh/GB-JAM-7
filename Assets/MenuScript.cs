using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuScript : MonoBehaviour
{

    [SerializeField] string[] SceneNames;
    [SerializeField] Transform[] uIPositions;
    [SerializeField] Texture[] paletteOpcions;
    [SerializeField] GameObject pointer;
    [SerializeField] TMP_Text paleteText;
    [SerializeField] PlayerController controller;
    private int i = 0;
    private int j = 0;
    bool once = false;
    bool pressed = false;
    bool pressedV = false;
    void Awake()
    {
        paleteText.text = string.Concat("Palette", "<", paletteOpcions[j].name.ToString(), ">");
        PaletteSwapLookup.LookupTexture = paletteOpcions[j];
    }
    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Intro");
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.Vertical < 0 && !pressedV)
        {
            i = i + 1 >= uIPositions.Length ? 0 : ++i;
            pressedV = true;
        }
        if (controller.Vertical > 0 && !pressedV)
        {
            i = i - 1 < 0 ? uIPositions.Length - 1 : --i;
            pressedV = true;
        }
        else if (controller.Vertical == 0)
        {
            pressedV = false;
        }
        pointer.transform.position = uIPositions[i].position;
        switch (i)
        {
            case 0:
                {
                    if (controller.Buttom_A && !once)
                    {
                        SceneScript.ChangeScene(SceneNames[0]);
                        once = true;
                                          FindObjectOfType<AudioManager>().Stop("Intro");

                    }
                    break;
                }
            case 1:
                {
                    Debug.Log(paletteOpcions.Length);
                    Debug.Log(j - 1 + " =j - 1");
                    Debug.Log(j - 1 <= 0);

                    if (controller.Horizontal < 0 && !pressed)
                    {
                        j = j - 1 < 0 ? paletteOpcions.Length - 1 : --j;
                        pressed = true;
                    }
                    if (controller.Horizontal > 0 && !pressed)
                    {
                        j = j + 1 >= paletteOpcions.Length ? 0 : ++j;
                        pressed = true;
                    }
                    else if (controller.Horizontal == 0)
                    {
                        pressed = false;
                    }
                    paleteText.text = string.Concat("Palette", "<", paletteOpcions[j].name.ToString(), ">");
                    PaletteSwapLookup.LookupTexture = paletteOpcions[j];
                    break;
                }
            case 2:
                {
                    if (controller.Buttom_A && !once)
                    {
                        SceneScript.ChangeScene(SceneNames[1]);
                        once = true;
                                          FindObjectOfType<AudioManager>().Stop("Intro");

                    }
                    break;
                }
        }

    }
}


