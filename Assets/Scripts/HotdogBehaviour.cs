using UnityEngine;

public class HotdogBehaviour : MonoBehaviour
{
    [Range(0.5f, 3)]
    public float leanHeight = 1f;

    [SerializeField] ParticleSystem vfx;
    private void Start()
    {
        LeanTween.moveY(this.gameObject, this.gameObject.transform.position.y + leanHeight, 0.5f).setLoopPingPong();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //instantiate VFX
            Instantiate(vfx, this.transform.position, Quaternion.identity);

            GameManager.shared.AddHotdog();

            AudioManager.shared.Play("PickUp",0.5f,Random.Range(1f,1.5f),0f);

            Destroy(this.gameObject);
        }

    }
}
