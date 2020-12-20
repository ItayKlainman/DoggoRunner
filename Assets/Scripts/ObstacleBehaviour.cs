using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    private float playerMovmentSpeed;
    public float slowDuration = 1f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
            {
            GameManager.shared.RemoveHotdog();
            //slow doggo
            playerMovmentSpeed =  PlayerMovement.shared.movementSpeed;
            PlayerMovement.shared.movementSpeed -= (PlayerMovement.shared.movementSpeed/3);
            Invoke("ReturnMovementSpeed",slowDuration);

            //sound
            AudioManager.shared.Play("WoodHit", 0.5f, Random.Range(1f, 2.5f), 0);
            AudioManager.shared.Play("DogWhine", 0.5f, Random.Range(1f, 1.5f), 0);
            }
    }

    private void ReturnMovementSpeed()
    {
        PlayerMovement.shared.movementSpeed = playerMovmentSpeed;
    }
}

