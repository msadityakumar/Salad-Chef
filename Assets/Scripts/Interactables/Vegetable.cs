using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "Vegetable", menuName = "ScriptableObjects/Vegetable")]
public class Vegetable : ScriptableObject
{
    public string VegetableName;
    public char VegetableCode;
    public Color VeggieColor;
}
