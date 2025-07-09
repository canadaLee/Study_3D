using System.Collections.Generic;
using UnityEngine;

public class DynamicArray : MonoBehaviour
{
    private object[] array = new object[3];

    public List<int> list1 = new List<int>();

    private void Start()
    {
        for (int i = 0; i <=10; i++)
        {
            list1.Add(i);
        }
        list1.Insert(5, 100);
    }

    void Add(object o)
    {
        var temp = new object[array.Length + 1];
        for (int i = 0; i < array.Length; i++)
        {
            temp[i] = array[i];
        }

        array = temp;
        array[array.Length - 1] = o;
    }

}
