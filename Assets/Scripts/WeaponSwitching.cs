using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;
    public bool canSwitchWeapon = true;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if (canSwitchWeapon && Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }

        if (canSwitchWeapon && Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedWeapon = 1;
        }

        if (canSwitchWeapon && Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedWeapon = 2;
        }
        
        SelectWeapon();
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform) 
        {
            if (i == selectedWeapon) 
                weapon.gameObject.SetActive(true);
            else 
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
