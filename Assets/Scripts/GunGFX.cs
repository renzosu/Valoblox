using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunGFX : MonoBehaviour
{
    #region Singleton

    public static GunGFX instance;

    private void Awake() 
    {
        instance = this;
    }

    #endregion

    public GameObject muzzleFlash;
    public Transform firePoint;
    public Vector3 angle = new Vector3(0, -90, 0);

    private Quaternion spawnAngle;

    private void Start() 
    {
        spawnAngle = Quaternion.Euler(angle);
    }

    public void ShootGunGFX()
    {
        Instantiate(muzzleFlash, firePoint.position, spawnAngle); 
    }
}
