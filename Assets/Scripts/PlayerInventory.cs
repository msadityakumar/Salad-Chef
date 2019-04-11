using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private Queue<Vegetable> m_InventoryQueue;

    public int MaxInventorySize = 2;

    public void Start()
    {
        m_InventoryQueue = new Queue<Vegetable>();
    }

    public void AddObjectToInventory(Vegetable obj)
    {
        if (m_InventoryQueue.Count < MaxInventorySize)
        {
            m_InventoryQueue.Enqueue(obj);
            PrintAllElementsInInventory();
        }
    }

    void PrintAllElementsInInventory()
    {
        foreach (var ele in m_InventoryQueue)
        {
            Debug.Log(ele.VegetableName +" "+ ele.VegetableCode);
        }
    }

    public int GetInventorySize()
    {
        return m_InventoryQueue.Count;
    }
}
