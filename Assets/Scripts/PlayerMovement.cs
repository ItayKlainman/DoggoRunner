using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement shared;

    [Header("Movement parameters")]
    public float movementSpeed;
    public float jumpForce;


    private float timeBetweenBarks = 1;
    public float barktimer = 0;
    private bool isgrounded = true;
    [HideInInspector]
    public bool hasreachedgoal = false;


    #region Singleton
    private void Awake()
    {
        if (shared != null)
        {
            Debug.LogError("PlayerMovement: Someone's trying to add another instance of this singleton");
            return;
        }
        shared = this;
    }
    #endregion
    private void Start()
    {
        timeBetweenBarks = Random.Range(4, 8);
    }

    private void Update()
    {
        if (!hasreachedgoal)
        {
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }

        if ((Time.time - barktimer) > timeBetweenBarks)
        {
            barktimer = 0;
            AudioManager.shared.Play("Bark", 0.4f, Random.Range(1.5f, 2.3f), 0);
            barktimer = Time.time;
        }
    }



    public void Jump()
    {
        if (isgrounded && !hasreachedgoal)
        {
            LeanTween.moveLocalY(gameObject, 15, 0.7f).setEaseOutCubic().setOnComplete(Drop);
            isgrounded = false;
            AudioManager.shared.Play("Jump", 0.5f, 1f, 0f);
        }
    }

    private void Drop()
    {
        LeanTween.moveLocalY(gameObject, 1.78f, 0.7f).setEaseOutSine();
        isgrounded = true;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer.Equals(8))
        {
            isgrounded = true;
        }
    }



}
