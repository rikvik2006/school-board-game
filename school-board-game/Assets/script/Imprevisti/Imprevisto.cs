using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewImprevisto", menuName = "Imprevisto")]
public class Imprevisto : ScriptableObject
{
    public new string name;
    [TextArea]
    public string description;
}
