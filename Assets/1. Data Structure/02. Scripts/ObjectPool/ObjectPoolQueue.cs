using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolQueue : MonoBehaviour
{
    public Queue<GameObject> objQueue = new Queue<GameObject>();

    public GameObject objPrefab;
    public Transform parent;

    private void Start()
    {
        CreateObject();
    }

    private void CreateObject()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject obj = Instantiate(objPrefab, parent);
            EnqueueObject(obj);
        }
    }

    public void EnqueueObject(GameObject g)
    {
        //물리적인 초기화작업
        g.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        g.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        objQueue.Enqueue(g);
        g.SetActive(false);
    }

    public GameObject DequeueObject()
    {
        if (objQueue.Count < 10)
            CreateObject();

        GameObject obj = objQueue.Dequeue();
        obj.SetActive(true);

        return obj;
    }
}
