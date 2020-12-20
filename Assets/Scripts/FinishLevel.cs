using Lean.Touch;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    public ParticleSystem[] vfx;
    public Animator playerAnim;
    public LeanDragTranslate drag;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.shared.WinLevel();
            UIManager.shared.EnableWinPanel();
            PlayerMovement.shared.movementSpeed = 0;
            playerAnim.SetTrigger("Idle");
            AudioManager.shared.Play("Win", 0.5f, 1f, 0f);
            drag.Sensitivity = 0;
            


            foreach(ParticleSystem particle in vfx)
            {
                particle.Play();
            }
        }
    }
}
