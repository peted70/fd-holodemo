using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackedBottlesScript : MonoBehaviour
{
    public void ResetBottles()
    {
        var children = GetComponentsInChildren<BottleScript>();
        foreach (var child in children)
        {
            child.Reset();
        }
    }

    public void InitPhysics()
    {
        var children = GetComponentsInChildren<BottleScript>();
        foreach (var child in children)
        {
            child.Placed();
        }
    }
}
