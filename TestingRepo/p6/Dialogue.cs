﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {
    // Information
    public string displayName;
    [TextArea(3,10)]
    public string[] sentences;
}
