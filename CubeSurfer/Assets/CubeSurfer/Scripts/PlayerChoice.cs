using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChoice : MonoBehaviour
{
    private GameObject mainChar;
    private string charName;

    public GameObject Ty;
    public GameObject Claire;
    public GameObject Jolleen;
    // Start is called before the first frame update
    void Start()
    {
        charName = PlayerPrefs.GetString("charname");

        if (charName == "TyPlayIdle")
        {
            mainChar = Ty;
            mainChar.SetActive(true);
        }
        else if (charName == "ClairePlayIdle")
        {
            mainChar = Claire;
            mainChar.SetActive(true);
        }
        else if (charName == "JolleenPlayIdle")
        {
            mainChar = Jolleen;
            mainChar.SetActive(true);
        }
        else
        {
            mainChar = Ty;
            mainChar.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
