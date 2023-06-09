using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using UnityEngine.SceneManagement;

public class CubeDetector : MonoBehaviour
{
    public GameObject MenuButton;
    public GameObject RestartButton;
    public GameObject NextLevelButton;
    public GameObject DoubleCoinButton;
   // public Text score=0;
    public TextMeshProUGUI text;
    public static int collectedBonus;
    //public Text score;
    int PlayerCoin=0;

    AudioSource Voice;
    public AudioClip getCoin;

    public AudioClip success;

    private void Awake()
    {
        Singleton();
    }

    #region Singleton

    public static CubeDetector Instance;

    private void Singleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
    }

    #endregion




    void Start()
    {
        Voice = GetComponent<AudioSource>();
        text.text = CubeDetector.collectedBonus.ToString();

    }




    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            //Debug.Log($"Cube {collision.gameObject.name}");

            var cubeBehaviour = collision.gameObject.GetComponent<CubeBehaviour>();

            if (!cubeBehaviour.isStacked)
            {
                PlayerCubeManager.Instance.GetCube(cubeBehaviour);
            }
        }

    }
   
    private void OnTriggerEnter(Collider collision) {


        if (collision.gameObject.tag=="Coin")
        {
            collectedBonus += 25;
            text.text = CubeDetector.collectedBonus.ToString();

            //  Debug.Log("COIN TOPLANDI");
            Destroy(collision.gameObject);
            Voice.PlayOneShot(getCoin);
          //  PlayerCoin++;
     //     string flag = ToString(PlayerCoin);
            //score.text = "score:"+PlayerCoin;
        }


        if (collision.gameObject.tag == "Finish")
        {
            GameManager.Instance.isFinished = true;

            PlayerBehaviour.Instance.StopPlayer();

            PlayerBehaviour.Instance.VictoryAnimation();

            var playerTransform2 = PlayerBehaviour.Instance.transform;
            Vector3 groundTarget = new Vector3(0f, -0.195f, -0.14f);
            playerTransform2.DOLocalJump(groundTarget, 0.05f, 1, 0.5f);

            Voice.PlayOneShot(success);

            MenuButton.SetActive(true);
            RestartButton.SetActive(true);
            NextLevelButton.SetActive(true);

            GameManager.Instance.ShowInterstitialAd();

            DoubleCoinButton.SetActive(true);

            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }



    }
  

}
