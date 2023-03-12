using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DumpToConsoleClass
{
    public static void DumpToConsole(object obj)
    {
        var output = JsonUtility.ToJson(obj, true);
        Debug.Log(output);
    }
}
