using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int EnemiesToSpawn;
    public GameObject[] EnemyPrefab = new GameObject[4];
    public int randomIndex;

    private void Start()
    {
        dropCoins();
    }

    public void dropCoins()
    {
        for (int i = 0; i < EnemiesToSpawn; i++)
        {
            randomIndex = Random.Range(0, 3);
            GameObject temp = Instantiate(EnemyPrefab[randomIndex]);
            temp.transform.position = GetRandomPointInCollider(GetComponent<BoxCollider>());
        }
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y), Random.Range(collider.bounds.min.z, collider.bounds.max.z));
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }
        point.y = 1;
        return point;
    }
}
