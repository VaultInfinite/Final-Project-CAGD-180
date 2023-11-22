using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public int CoinsContained;
    public GameObject CoinPrefab;
    public GameObject crate;

    public void dropCoins()
    {
        for (int i = 0; i < CoinsContained; i++)
        {
            GameObject temp = Instantiate(CoinPrefab);
            temp.transform.position = GetRandomPointInCollider(GetComponent<BoxCollider>());
        }
        crate.GetComponent<MeshRenderer>().enabled=false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
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
