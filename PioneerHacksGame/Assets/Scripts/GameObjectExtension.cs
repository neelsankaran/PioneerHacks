using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExtension
{
    public static void interact(this GameObject obj)
    {
        obj.GetComponent<Interactable>().interact();
    }
}