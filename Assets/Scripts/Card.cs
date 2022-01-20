﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private GameEvent OnCardSelected;

    private void OnMouseDown()
    {
        OnCardSelected.Raise();
    }

}