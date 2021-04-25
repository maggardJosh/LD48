using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public float minX = -1f;
    public float maxX = 1f;

    [Range(0,1)]
    public float randomChance = .2f;
    public float randomTimeCheck = .1f;

    public GameObject[] bubblePrefabs;

    private float count = 0;
    void Update()
    {
        if (randomTimeCheck <= 0)
            return;
        count += Time.deltaTime;
        while (count > randomTimeCheck)
        {
            count -= 1;
            count -= randomTimeCheck;
            if (Random.Range(0f, 1) <= randomChance)
            {
                float randomXPos = Random.Range(minX, maxX);
                int prefabInd = Random.Range(0, bubblePrefabs.Length);
                Instantiate(bubblePrefabs[prefabInd], transform.position + Vector3.right * randomXPos, Quaternion.identity);
            }
        }
    }
}
