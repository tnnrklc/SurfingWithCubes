using DG.Tweening;

using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private string charName;

    public Animator animatorOfPlayer1;
    public Animator animatorOfPlayer2;
    public Animator animatorOfPlayer3;

    public PlayerMoverRunner playerMoverRunner;

    private void Start()
    {
        charName = PlayerPrefs.GetString("charname");
    }

    private void Awake()
    {
        Singleton();
    }

    #region Singleton

    public static PlayerBehaviour Instance;

    private void Singleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
    }

    #endregion

    public void VictoryAnimation()
    {
        if(charName == "TyPlayIdle")
        {
            animatorOfPlayer1.SetTrigger("Victory");
        }
        else if (charName == "ClairePlayIdle")
        {
            animatorOfPlayer2.SetTrigger("Victory");
        }
        else if (charName == "JolleenPlayIdle")
        {
            animatorOfPlayer3.SetTrigger("Victory");
        }
    }

    public void FailAnimation()
    {
        if (charName == "TyPlayIdle")
        {
            animatorOfPlayer1.SetTrigger("Fail");
        }
        else if (charName == "ClairePlayIdle")
        {
            animatorOfPlayer2.SetTrigger("Fail");
        }
        else if (charName == "JolleenPlayIdle")
        {
            animatorOfPlayer3.SetTrigger("Fail");
        }
    }

    public void StopPlayer()
    {
        DOTween.To(() => playerMoverRunner.Velocity, x => playerMoverRunner.Velocity = x, 0, 0.003f);
    }


}
