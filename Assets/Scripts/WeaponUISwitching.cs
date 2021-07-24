using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUISwitching : MonoBehaviour
{
    public int selectedWeaponUI = 0;
    public bool canSwitchWeaponUI = true;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeaponUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (canSwitchWeaponUI && Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeaponUI = 0;
        }

        if (canSwitchWeaponUI && Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedWeaponUI = 1;
        }

        if (canSwitchWeaponUI && Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedWeaponUI = 2;
        }
        
        SelectWeaponUI();
    }

    void SelectWeaponUI()
    {
        int i = 0;
        foreach (Transform weaponUI in transform) 
        {
            if (i == selectedWeaponUI) 
                weaponUI.gameObject.SetActive(true);
            else 
                weaponUI.gameObject.SetActive(false);
            i++;
        }
    }
}
