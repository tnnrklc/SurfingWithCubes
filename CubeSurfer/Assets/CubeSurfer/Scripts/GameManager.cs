using UnityEngine;
using HmsPlugin;
using UnityEngine.SceneManagement;
using HuaweiMobileServices.Ads;
using HuaweiMobileServices.Ads.NativeAd;
using HuaweiMobileServices.Id;
using HuaweiMobileServices.Utils;
using HuaweiMobileServices.IAP;
using System.Collections.Generic;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    //public TextMeshProUGUI text;

    static private int level = 1;

    static public bool[] lvlList = new bool[7];

    public bool isFinished = false;

    public bool interstitialAdd = false;

    public bool isAdRewarded = false;

    public int isOwned = 0;

    public int isOwnedCoin = 0;

    public string isAuth;

    private Scene scene;

    /*public SwerveMovement SwerveMovement;
    public SwerveInputSystem SwerveInputSystem;
    public PlayerMover PlayerMover;

    public RectTransform WinUI;
    public RectTransform FailUI;*/

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        Instance = this;
    }

    private void Start()
    {
        PlayerPrefs.SetInt("level1", 1);

        HMSAdsKitManager.Instance.OnRewardAdCompleted = OnRewardAdCompleted;
    }

    public void NoAdsButton()
    {
        HMSIAPManager.Instance.OnBuyProductSuccess = OnBuyProductSuccess;
        HMSIAPManager.Instance.BuyProduct(HMSIAPConstants.prod002);
    }

    public void DoubleCoinButton()
    {
        HMSIAPManager.Instance.OnBuyProductSuccess = OnBuyProductSuccess;
        HMSIAPManager.Instance.BuyProduct(HMSIAPConstants.prod001);
        CubeDetector.collectedBonus*=2;
    }

    private void OnBuyProductSuccess(PurchaseResultInfo result)
    {
        if (result.InAppPurchaseData.ProductId == HMSIAPConstants.prod002)
        {
            // Write your remove ads logic here.
            Debug.Log("OnBuyProductSuccess");
            PlayerPrefs.SetInt("isOwned", 1);
            isOwned = 1;
            HMSAdsKitManager.Instance.HideBannerAd();
        }

        if (result.InAppPurchaseData.ProductId == HMSIAPConstants.prod001)
        {
            // Write your remove ads logic here.
            Debug.Log("OnBuyProductSuccess");
            PlayerPrefs.SetInt("isOwnedCoin", 1);
            isOwnedCoin = 1;
            CubeDetector.collectedBonus=CubeDetector.collectedBonus*2;
            //text.text = CubeDetector.collectedBonus.ToString();
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void SignIn()
    {
        Debug.Log("SignIn");
        HMSAccountKitManager.Instance.OnSignInSuccess = SignInSuccess;
        HMSAccountKitManager.Instance.OnSignInFailed = SignInFailed;
        HMSAccountKitManager.Instance.SignIn();
    }

    private void SignInSuccess(AuthAccount authAccount)
    {
        PlayerPrefs.SetString("SignIn", "signedin");
        Debug.Log("SignInSuccess" + authAccount.DisplayName);
    }

    private void SignInFailed(HMSException exception)
    {
        PlayerPrefs.SetString("SignIn", "signedinfailed");
        Debug.Log("SignInFailed" + exception);
    }

    private void Update()
    {
        scene = SceneManager.GetActiveScene();

        if (scene.name == "level1")
        {
            if (isFinished == true)
            {
                PlayerPrefs.SetInt("level2", 1);
                //lvlList[2] = true;
            }
        }
        else if (scene.name == "level2")
        {
            if (isFinished == true)
            {
                PlayerPrefs.SetInt("level3", 1);
                //lvlList[3] = true;
            }
        }
        else if (scene.name == "level3")
        {
            if (isFinished == true)
            {
                PlayerPrefs.SetInt("level4", 1);
                //lvlList[4] = true;
            }
        }
        else if (scene.name == "level4")
        {
            if (isFinished == true)
            {
                PlayerPrefs.SetInt("level5", 1);
                //lvlList[5] = true;
            }
        }
        else if (scene.name == "level5")
        {
            if (isFinished == true)
            {
                PlayerPrefs.SetInt("level6", 1);
                //lvlList[6] = true;
            }
        }
        else if (scene.name == "level6")
        {
            if (isFinished == true)
            {
                //PlayerPrefs.SetBool("level1", true);
                //lvlList[6] = true;
            }
        }

        if(isAdRewarded)
        {
            isFinished = true;
            NextLevel();
        }
    }

    public void ShowInterstitialAd()
    {
        isOwned = PlayerPrefs.GetInt("IsOwned");

        if(isOwned == 1) return;
        HMSAdsKitManager.Instance.ShowInterstitialAd();
    }

    /*public void ActivateWinUI()
    {
        WinUI.gameObject.SetActive(true);
        Vector3 defaultScale = WinUI.transform.localScale;

        WinUI.transform.localScale = Vector3.one * 0.0001f;
        WinUI.DOScale(defaultScale, 1f).SetEase(Ease.OutBounce);
    }

    public void ActivateFailUI()
    {
        FailUI.gameObject.SetActive(true);
        Vector3 defaultScale = FailUI.transform.localScale;

        FailUI.transform.localScale = Vector3.one * 0.0001f;
        FailUI.DOScale(defaultScale, 1f).SetEase(Ease.OutBounce);
    }*/

    public void StartGame()
    {    
        if (PlayerPrefs.GetInt("level") == 0)
        {
            //isFinished = false;
            //interstitialAdd = false;
            PlayerPrefs.SetInt("level", 1);
            //lvlList[level] = true;
        }

        level = PlayerPrefs.GetInt("level");
        SceneManager.LoadScene(level);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        CubeDetector.collectedBonus=0;
        if (scene.name == "level1")
        {
            SceneManager.LoadScene("level1");
        }
        else if (scene.name == "level2")
        {
            SceneManager.LoadScene("level2");
        }
        else if (scene.name == "level3")
        {
            SceneManager.LoadScene("level3");
        }
        else if (scene.name == "level4")
        {
            SceneManager.LoadScene("level4");
        }
        else if (scene.name == "level5")
        {
            SceneManager.LoadScene("level5");
        }
        else if (scene.name == "level6")
        {
            SceneManager.LoadScene("level6");
        }
    }

    public void RewardAddButton()
    {    
        HMSAdsKitManager.Instance.ShowRewardedAd();
    }

    public void OnRewardAdCompleted()
    {
        Debug.Log("[HMS] HMSAdsKitManager OnRewardAdCompleted!");
        isAdRewarded = true;
    }

    public void NextLevel()
    {
        level = PlayerPrefs.GetInt("level");

        if(scene.name == "level1" && isFinished == true)
        {
            level = 2;
            PlayerPrefs.SetInt("level", level);
            SceneManager.LoadScene(level);
        }
        else if (scene.name == "level2" && isFinished == true)
        {
            if (isFinished == true)
            {
                lvlList[level] = true;
            }

            level = 3;
            PlayerPrefs.SetInt("level", level);
            SceneManager.LoadScene(level);
        }
        else if (scene.name == "level3" && isFinished == true)
        {
            if (isFinished == true)
            {
                lvlList[level] = true;
            }

            level = 4;
            PlayerPrefs.SetInt("level", level);
            SceneManager.LoadScene(level);
        }
        else if (scene.name == "level4" && isFinished == true)
        {
            if (isFinished == true)
            {
                lvlList[level] = true;
            }

            level = 5;
            PlayerPrefs.SetInt("level", level);
            SceneManager.LoadScene(level);
        }
        else if (scene.name == "level5" && isFinished == true)
        {
            if (isFinished == true)
            {
                lvlList[level] = true;
            }

            level = 6;
            PlayerPrefs.SetInt("level", level);
            SceneManager.LoadScene(level);
        }
        else if (scene.name == "level6" && isFinished == true)
        {
            if (isFinished == true)
            {
                lvlList[level] = true;
            }

            level = 1;
            PlayerPrefs.SetInt("level", level);
            SceneManager.LoadScene(level);
        }
    }

    public void OpenLevel1()
    {
        if (PlayerPrefs.GetInt("level1") == 1)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void OpenLevel2()
    {
        if (PlayerPrefs.GetInt("level2") == 1)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void OpenLevel3()
    {
        if (PlayerPrefs.GetInt("level3") == 1)
        {
            SceneManager.LoadScene(3);
        }
    }

    public void OpenLevel4()
    {
        if (PlayerPrefs.GetInt("level4") == 1)
        {
            SceneManager.LoadScene(4);
        }
    }

    public void OpenLevel5()
    {
        if (PlayerPrefs.GetInt("level5") == 1)
        {
            SceneManager.LoadScene(5);
        }
    }

    public void OpenLevel6()
    {
        if (PlayerPrefs.GetInt("level6") == 1)
        {
            SceneManager.LoadScene(6);
        }
    }
}
