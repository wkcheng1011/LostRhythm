using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    public static readonly int NOTE_SIZE = 128;
    public enum NOTE_TYPE
    {
        NORMAL,
        SPECIAL,
        BOMB
    }
    public static readonly Dictionary<NOTE_TYPE, double> NOTE_PROB = new Dictionary<NOTE_TYPE, double>() {
        { NOTE_TYPE.NORMAL, 0.7 },
        { NOTE_TYPE.BOMB, 0.2 },
        { NOTE_TYPE.SPECIAL, 0.1 }
    };

    public static readonly int PLATE_SPEED = 1000;

    public static readonly int DIFF_COEFF = 8;
}
