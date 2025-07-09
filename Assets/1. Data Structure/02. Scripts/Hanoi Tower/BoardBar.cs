using System;
using System.Collections.Generic;
using UnityEngine;

public class BoardBar : MonoBehaviour
{
    public enum BarType { Left,Center,Right}
    public BarType barType;

    public Stack<GameObject> barStack = new Stack<GameObject>();



    private void OnMouseDown()
    {
        if (!HanoiTower.isSelected)
        {
            HanoiTower.isSelected = true;
            HanoiTower.selectedDonut = PopDonut();
        }
        else
        {
            PushDonut(HanoiTower.selectedDonut);
        }
    }
    public bool CheckDonut(GameObject donut)
    {
        if(barStack.Count> 0)
        {
            int pushNumber = donut.GetComponent<Donut>().donut_Number;

            GameObject peekDonut = barStack.Peek();

            int peekNumber = peekDonut.GetComponent<Donut>().donut_Number;

            if (pushNumber < peekNumber)
                return true;
            else
                return false;
        }
        return true;
    }

    public void PushDonut(GameObject donut)
    {
        if (!CheckDonut(donut))
            return;

        HanoiTower.isSelected = false;
        HanoiTower.selectedDonut = null;

    donut.transform.position = transform.position + Vector3.up * 5f;
        donut.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        donut.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        barStack.Push(donut);
    }


    public GameObject PopDonut()
    {
        GameObject donut = barStack.Pop();

        return donut;
    }
}
