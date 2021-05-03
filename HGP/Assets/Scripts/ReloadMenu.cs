using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ReloadMenu
{
    private static bool reloaded;
    public static bool Reloaded
    {
        get
        {
            return reloaded;
        }
        set
        {
            reloaded = value;
        }
    }
}
