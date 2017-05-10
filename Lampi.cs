using System;
using System.Collections.Generic;
using UnityEngine;

namespace LampiTest
{
    [Serializable]
    public class Lampi
    {
        public Color color;
        public float brightness;
        public bool on;
    }

    [Serializable]
    public class Color
    {
        public float h;
        public float s;
    }
}
