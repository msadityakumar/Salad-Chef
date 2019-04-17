using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerData
{
    public Vegetable Veggie1;
    public Vegetable Veggie2;
    public Salad Salad;
}

public class PlayerInventory : MonoBehaviour
{
    private Queue<Vegetable> m_InventoryQueue;
    private PlayerData m_PlayerData;

    public int MaxInventorySize = 2;

    public void Start()
    {
        m_InventoryQueue = new Queue<Vegetable>();
        m_PlayerData = new PlayerData();
    }

    public void AddObjectToInventory(Vegetable obj)
    {
        if (m_InventoryQueue.Count < MaxInventorySize)
        {
            m_InventoryQueue.Enqueue(obj);
            PrintAllElementsInInventory();
        }
    }

    public PlayerData GetPlayerData()
    {
        m_PlayerData.Veggie1 =  m_InventoryQueue.ElementAtOrDefault(0);
        m_PlayerData.Veggie2 = m_InventoryQueue.ElementAtOrDefault(1);
        return m_PlayerData;
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

    public void Update()
    {
        //continously update the current inventory on the display
         
        
    }
}
