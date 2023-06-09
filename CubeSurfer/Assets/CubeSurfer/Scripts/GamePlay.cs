using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    private int i = 0;
    private GameObject mainChar;
    private GameObject Ty;
    private GameObject Claire;
    private GameObject Jolleen;

    public GameObject[] charList = new GameObject[3];

    public GameObject charCanvas;
    public GameObject IntroCanvas;
    public GameObject AdCanvas;
    public GameObject LevelCanvas;
    public GameObject HowToPlayCanvas;
    public GameObject Characters;

    // Start is called before the first frame update
    void Start()
    {
        IntroCanvas.SetActive(true);
        charCanvas.SetActive(false);
        HowToPlayCanvas.SetActive(false);
        //ProductCanvas.SetActive(false);
        LevelCanvas.SetActive(false);

        if(PlayerPrefs.GetInt("is_set") == 0)
        {
            PlayerPrefs.SetString("charname", "TyPlayIdle");
        }

        charList[0].SetActive(false);
        charList[1].SetActive(false);
        charList[2].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GoToProducts()
    {
        IntroCanvas.SetActive(false);
        charCanvas.SetActive(false);
        HowToPlayCanvas.SetActive(false);
        LevelCanvas.SetActive(false);
        //ProductCanvas.SetActive(true);
    }


    public void NextCharacter()
    {
        if(i + 1 < charList.Length)
        {
            charList[i].SetActive(false);
            charList[++i].SetActive(true);
        }
    }

    public void PrevCharacter()
    {
        if(i - 1 >= 0)
        {
            charList[i].SetActive(false);
            charList[--i].SetActive(true);
        }
    }

    public void GoToChars()
    {
        IntroCanvas.SetActive(false);
        HowToPlayCanvas.SetActive(false);
        LevelCanvas.SetActive(false);
        AdCanvas.SetActive(false);
        Characters.SetActive(true);
        charCanvas.SetActive(true);
        charList[0].SetActive(true);
        charList[1].SetActive(false);
        charList[2].SetActive(false);
    }

    public void MainMenu()
    {
        IntroCanvas.SetActive(true);
        charCanvas.SetActive(false);
        LevelCanvas.SetActive(false);
        HowToPlayCanvas.SetActive(false);
        AdCanvas.SetActive(true);
        charList[0].SetActive(false);
        charList[1].SetActive(false);
        charList[2].SetActive(false);
    }

    public void Select()
    {
        if (i == 0)
        {
            PlayerPrefs.SetString("charname", "TyPlayIdle");
            PlayerPrefs.SetInt("is_set", 1);
        }
        else if(i == 1)
        {
            PlayerPrefs.SetString("charname", "ClairePlayIdle");
            PlayerPrefs.SetInt("is_set", 1);
        }
        else if (i == 2)
        {
            PlayerPrefs.SetString("charname", "JolleenPlayIdle");
            PlayerPrefs.SetInt("is_set", 1);
        }
    }

    public void Levels()
    {
        IntroCanvas.SetActive(false);
        charCanvas.SetActive(false);
        HowToPlayCanvas.SetActive(false);
        AdCanvas.SetActive(false);
        LevelCanvas.SetActive(true);
    }

    public void HowToPlay()
    {
        if (HowToPlayCanvas.activeInHierarchy == false)
        {
            AdCanvas.SetActive(false);
            HowToPlayCanvas.SetActive(true);
        }
        else if(HowToPlayCanvas.activeInHierarchy == true)
        {
            HowToPlayCanvas.SetActive(false);
            AdCanvas.SetActive(true);
        }
    }
}
