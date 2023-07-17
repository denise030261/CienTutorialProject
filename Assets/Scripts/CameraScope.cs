using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScope : MonoBehaviour
{
    public static CameraScope Instance { get; private set; } = null;
    public int minX = -10;
    public int maxX = 10;
    public int minY = -5;
    public int maxY = 5;

    private void Awake()
    {
        Instance = this;
    }
}
