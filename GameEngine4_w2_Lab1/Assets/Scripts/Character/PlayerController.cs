using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character.UI;

public class PlayerController : MonoBehaviour
{
    public Crosshair Crosshair => crosshairComponent;
    [SerializeField] private Crosshair crosshairComponent; 

    public bool IsFiring;
    public bool IsReloading;
    public bool IsJumping;
    public bool IsRunning;
}
