using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Group
{
    Group1,
    Group2
}

public class Card : MonoBehaviour
{
    [SerializeField] private GameEvent OnCardSelected;
    [SerializeField] private Group group;

    private void OnMouseDown()
    {
        OnCardSelected.Raise();
    }

}
