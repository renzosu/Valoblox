using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    public Animator animator;

    public GameObject scopeOverlay;
    public GameObject weaponCamera;
    public GameObject crosshair;
    public GameObject weaponHolder;
    public GameObject weaponUIHolder;

    public Camera mainCamera;

    public float scopedFOV = 15f;
    private float normalFOV;

    public float scopedSens = 0.2f;
    private float normalSens;

    private bool isScoped = false;
    private bool coolDown = false;
    private float coolDownTime = 1.0f;

    public AudioSource scopeVFX;

    void Update() 
    {
        if (Input.GetMouseButton(1))
        {
            if (coolDown == false) 
            {
                isScoped = !isScoped;
                animator.SetBool("Scoped", isScoped);

                if (isScoped)
                    StartCoroutine(OnScoped());
                else 
                    OnUnscoped();

                Invoke("ResetCoolDown", coolDownTime);
                coolDown = true;
            }
        }

        if (Input.GetMouseButton(0) && isScoped)
        {
            isScoped = false;
            animator.SetBool("Scoped", isScoped);
            OnUnscoped();
        }
    }

    void OnUnscoped() 
    {
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);
        crosshair.SetActive(true);

        mainCamera.fieldOfView = normalFOV;

        mainCamera.GetComponent<MouseLook>().mouseSensitivity = normalSens;

        weaponHolder.GetComponent<WeaponSwitching>().canSwitchWeapon = true;
        weaponUIHolder.GetComponent<WeaponUISwitching>().canSwitchWeaponUI = true;
    }

    IEnumerator OnScoped() 
    {
        yield return new WaitForSeconds(0.15f);

        if (scopeVFX != null)
        {
            scopeVFX.Play();
        }

        scopeOverlay.SetActive(true);
        weaponCamera.SetActive(false);
        crosshair.SetActive(false);

        normalFOV = mainCamera.fieldOfView;
        mainCamera.fieldOfView = scopedFOV;

        normalSens = mainCamera.GetComponent<MouseLook>().mouseSensitivity;
        mainCamera.GetComponent<MouseLook>().mouseSensitivity = scopedSens;

        weaponHolder.GetComponent<WeaponSwitching>().canSwitchWeapon = false;
        weaponUIHolder.GetComponent<WeaponUISwitching>().canSwitchWeaponUI = false;
    }

    void ResetCoolDown() {
        coolDown = false;
    }
}
