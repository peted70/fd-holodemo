using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    public void OnSelect()
    {
        transform.parent.GetComponent<TapToPlace>().SendMessage("OnSelect", SendMessageOptions.RequireReceiver);
        Debug.Log("propagate message");
    }
}
