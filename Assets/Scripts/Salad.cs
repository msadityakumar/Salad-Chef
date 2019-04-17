using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salad : MonoBehaviour
{
    private List<Vegetable> SaladCombination;

    public void Start()
    {
        SaladCombination = new List<Vegetable>();
    }

    public void AddVeggieToSalad(Vegetable veggie)
    {
        SaladCombination.Add(veggie);
    }

    public void ScrapSalad()
    {
        SaladCombination.Clear();
    }

    public List<Vegetable> GetSaladCombination()
    {
        return SaladCombination;
    }
}
