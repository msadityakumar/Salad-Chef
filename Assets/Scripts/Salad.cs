using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Salad
{
    private Queue<Vegetable> SaladCombination;

    public Salad()
    {
        SaladCombination = new Queue<Vegetable>();
    }

    public void AddVeggieToSalad(Vegetable veggie)
    {
        SaladCombination.Enqueue(veggie);
    }

    public Vegetable Dequeue()
    {
        return SaladCombination.Dequeue();
    }

    public void ScrapSalad()
    {
        SaladCombination.Clear();
    }

    public Queue<Vegetable> GetSaladCombination()
    {
        return SaladCombination;
    }

    public int GetSize()
    {
        return SaladCombination.Count;
    }

    public Vegetable GetElementAt(int index)
    {
        return SaladCombination.ElementAt(index);
    }

    public string GetSaladStringFromSalad()
    {
        string saladStr = string.Empty;
            int i = 0;
            while (i < SaladCombination.Count)
            {
                var veggie = SaladCombination.ElementAt(i);
                saladStr += veggie.VegetableCode.ToString() + " ";
                i++;
            }
            return saladStr;
     }

    public bool Equals(Salad otherSalad)
    {
        ///check for count if both have same number of elements

        if (SaladCombination.Count != otherSalad.GetSize())
            return false;

        //both the sizes are equal
        int count = GetSize() - 1;

        while (count > 0)
        {
            var veggie1 = SaladCombination.Dequeue();
            var veggie2 = otherSalad.Dequeue();

            if (!veggie1.VegetableCode.Equals(veggie2.VegetableCode))
                return false;

            count--;
        }

        return true;
    }
}
