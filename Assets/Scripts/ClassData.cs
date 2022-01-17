using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Class Data", menuName = "Class Data", order = 52)]


public class ClassData : ScriptableObject
{
    [SerializeField] private string className;
    public int score;
    public int index;

    public string ClassName => className;
    //public int Score => score;
}
