using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {

    public string name;

    [TextArea(3,10)]
    public string[] sentences;
    [TextArea(3, 10)]
    public string[] Firstsentences;
    [TextArea(3, 10)]
    public string[] Endsentences;
    [TextArea(3, 10)]
    public string[] Eventsentences;
}
