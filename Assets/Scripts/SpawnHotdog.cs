using UnityEngine;

public class SpawnHotdog : MonoBehaviour
{
    private ParticleSystem vfx;
    [SerializeField] private GameObject hotdog;
    [SerializeField] private Vector3 dropoffset;
    void Start()
    {
        vfx = GetComponent<ParticleSystem>();
        Invoke("SpawnHotDog", vfx.main.duration);
    }

    private void SpawnHotDog()
    {
        Instantiate(hotdog,(transform.position + dropoffset), Quaternion.identity);
        Destroy(this.gameObject);
    }
}
