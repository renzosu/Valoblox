using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeThrower : MonoBehaviour
{
    public float throwForce = 40f;
    public GameObject grenadePrefab;

    private bool coolDown = false;
    private float coolDownTime = 10.0f;
    private float coolDownTimer = 0f;

    public Text coolDownDisplay;

    // Update is called once per frame
    void Update()
    {
        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }

        if (coolDownTimer < 0)
        {
            coolDownTimer = 0;
        }

        if (Input.GetKeyDown(KeyCode.G)) 
        {
            if (coolDownTimer == 0) 
            {
                ThrowGrenade();
                //Invoke("ResetCoolDown", coolDownTime);
                coolDownTimer = coolDownTime;
            }
        }

        coolDownDisplay.text = Mathf.RoundToInt(coolDownTimer).ToString();
    }

    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }

    void ResetCoolDown() {
        coolDown = false;
    }
}
