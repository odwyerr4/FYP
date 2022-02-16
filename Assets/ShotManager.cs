using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class shot
{
    public float upForce;
    public float hitForce;
}

public class ShotManager : MonoBehaviour
{
    public shot lineDrive;
    public shot highHit;
}
