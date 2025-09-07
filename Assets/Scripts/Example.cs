using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    [ReadOnly]
    public int id = 42;
    [ReadOnly]
    public string version = "1.0.0";

    public float editableValue = 10f;
}
