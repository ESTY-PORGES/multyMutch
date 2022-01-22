using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pair Data", menuName = "Pair Data", order = 51)]


public class PairData : ScriptableObject
{
    [SerializeField] private string pairName;
    [SerializeField] private int group;
 
 
    public string PairName => pairName;
    public int Group => group;

   
}
