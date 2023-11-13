using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject myPrefab;

    public float time = 0;

    [Tooltip("Spawns the items with a random Y rotation.")]
    public bool randomYOrientation = false;

    float period = 0;

    private void Start()
    {
        period = time + 1;
    }

    void Update()
    {
        if (period > time)
        {
            Spawn();
            period = 0;
        }
        period += Time.deltaTime;
    }

    void Spawn()
    {
        if (randomYOrientation)
        {
            var spawnOrientation = Quaternion.Euler(
                myPrefab.transform.rotation.eulerAngles.x,
                Random.value * 360, 
                myPrefab.transform.rotation.eulerAngles.z);

            Instantiate(myPrefab, transform.position, spawnOrientation);
        }
        else
        {
            Instantiate(myPrefab, transform.position, myPrefab.transform.rotation);
        }

    }
}
