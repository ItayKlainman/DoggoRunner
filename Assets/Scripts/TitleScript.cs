using UnityEngine;

public class TitleScript : MonoBehaviour
{
   
    void Start()
    {
        LeanTween.moveY(gameObject, -250, 2).setEaseInBounce();    
    }

   

}
