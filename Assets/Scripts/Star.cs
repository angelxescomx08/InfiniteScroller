using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] private int points;

    public int GetPoints()
    {
        return points;
    }
}
