using UnityEngine;

public class PedestrianBehaviour : MonoBehaviour
{
    public Transform target;
    public float speed;

    private bool hasreachedgoal = false;

    public bool invertDirections;
    [HideInInspector]
    public bool startWalking = false;

    void Update()
    {
        if (startWalking)
        {

            if (!hasreachedgoal && !invertDirections)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                if (this.transform.position.x >= target.position.x)
                {
                    hasreachedgoal = true;
                    startWalking = false;
                    Destroy(gameObject, 4f);
                }
            }
            if (!hasreachedgoal && invertDirections)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                if (this.gameObject.transform.position.x <= target.localPosition.x)
                {
                    print("this:" + this.gameObject.transform.position.x);
                    print("Target:" + target.position.x);
                    hasreachedgoal = true;
                    startWalking = false;
                    Destroy(gameObject, 4f);
                }
            }
        }
    }
}
