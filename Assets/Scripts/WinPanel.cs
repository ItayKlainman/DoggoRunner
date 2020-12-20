using UnityEngine;

public class WinPanel : MonoBehaviour
{
    private void OnEnable()
    {
        LeanTween.moveY(gameObject, 650, 1.5f).setEaseOutBack().setOnComplete(UIManager.shared.ShowResult);
    }
}
