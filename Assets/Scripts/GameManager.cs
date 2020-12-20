using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager :MonoBehaviour
{
    public static GameManager shared;
    public int hotdogCount = 0;

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

    private void Start()
    {
        //FreezeTime();
    }
    public void WinLevel()
    {
        PlayerMovement.shared.hasreachedgoal = true;
        // add VFX     

        int result = CalculateStars();
        //LeanTween some pop up message that shows stars score and restart/continue Buttons.     
    }

    public int CalculateStars()
    {    
        int result;
        GameObject[] hotdogs = GameObject.FindGameObjectsWithTag("Drop");
        if (hotdogCount == hotdogs.Length)
        {
            result = 3;
        }
        else if (hotdogCount >= hotdogs.Length / 2)
        {
            result = 2;
        }
        else
        {
            result = 1;
        }
        print(result);

        return result;
    }
    public void AddHotdog()
    {
        hotdogCount++;
        UIManager.shared.UpdateHotDogCount(hotdogCount);
        UIManager.shared.PlusHotDog();
    }
    public void RemoveHotdog()
    {
        hotdogCount--;
        if(hotdogCount<0)
        {
            hotdogCount = 0;
        }
        UIManager.shared.UpdateHotDogCount(hotdogCount);
        UIManager.shared.MinusHotDog();
     
    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenDebugMenu()
    {
        if (Time.timeScale == 1)
        {
            FreezeTime();
            UIManager.shared.OpenDebugMenu();
        }
        else
        {
            UIManager.shared.CloseDebugMenu();
            ResetTimeScale();
        }
    }
    public void ResetTimeScale()
    {
        Time.timeScale = 1;
    }
    public void FreezeTime()
    {
        Time.timeScale = 0;
    }
}
