using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSaladGenerator : MonoBehaviour
{
    [SerializeField] private int m_MinVeggies;
    [SerializeField] private int m_MaxVeggies;

    [SerializeField] private Vegetable[] m_Vegetables;

    private Salad m_CustomerSalad;
    // Start is called before the first frame update
    void Awake()
    {
        m_CustomerSalad = new Salad();
        GenerateRandomSalad();
    }

    void GenerateRandomSalad()
    {
       int nRandomVeggies = Random.Range(m_MinVeggies, m_MaxVeggies);
        //generate nrandom 

        for (int i = 0; i < nRandomVeggies; i++)
        {
            int veggieIndex = Random.Range(0, m_Vegetables.Length);
            var veggie = m_Vegetables[veggieIndex];
            m_CustomerSalad.AddVeggieToSalad(veggie);
        }
    }

    public Salad GetCustomerSalad()
    {
        return m_CustomerSalad;
    }
}
