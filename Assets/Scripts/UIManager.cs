using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager shared;
    [SerializeField] private GameObject panel;
    [SerializeField] GameObject minus1, plus1;
    public TextMeshProUGUI hotdogText;


    [Header("Stars")]
    [SerializeField] private GameObject star1;
    [SerializeField] private GameObject star2;
    [SerializeField] private GameObject star3;


    [Header("Debug Menu")]
    [SerializeField] private GameObject dbPanel;


    #region Singleton
    private void Awake()
    {
        if (shared != null)
        {
            Debug.LogError("Game Manager: Someone's trying to add another instance of this singleton");
            return;
        }
        shared = this;
    }
    #endregion

    public void EnableWinPanel()
    {
        panel.SetActive(true);
    }

    public void UpdateHotDogCount(int amount)
    {
        hotdogText.text = amount.ToString();
        if (amount <= 0)
        {
            amount = 0;
        }
    }

    public void ShowResult()
    {
        int result = GameManager.shared.CalculateStars();
        if (result == 1)
        {
            LeanTween.moveLocalY(star1, 0, 1).setEaseOutElastic();
            //Play sound
        }
        if (result == 2)
        {
            LeanTween.moveLocalY(star1, 0, 0.75f).setEaseOutElastic().setOnComplete(Show2ndStar);
            //play sound at higher pitch
        }
        if (result == 3)
        {
            LeanTween.moveLocalY(star1, 0, 0.75f).setEaseOutElastic().setOnComplete(Show2ndStar);
            //play sound at even higher pitch
        }
    }
    private void Show2ndStar()
    {
        if (GameManager.shared.CalculateStars() == 3)
            LeanTween.moveLocalY(star2, 0, 0.75f).setEaseOutElastic().setOnComplete(Show3rdStar);
        else
        {
            LeanTween.moveLocalY(star2, 0, 0.75f).setEaseOutElastic();
        }

    }

    private void Show3rdStar()
    {
        LeanTween.moveLocalY(star3, 0, 0.75f).setEaseOutElastic();
    }

    public void OpenDebugMenu()
    {
        dbPanel.SetActive(true);   
    }
    public void CloseDebugMenu()
    {
        dbPanel.SetActive(false);
    }

    public void MinusHotDog()
    {
        minus1.SetActive(true);
    }
    public void PlusHotDog()
    {
        plus1.SetActive(true);
    }
}





