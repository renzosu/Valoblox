using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 8f;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1.5f;
    private bool isReloading = false;

    public Camera fpsCam;
    public GameObject impactEffect;

    public Animator animator;

    private float nextTimeToFire = 1f;

    private GunGFX gunGFX;

    public Text ammoDisplay;

    public AudioSource shootVFX;
    public AudioSource reloadVFX;

    void Start() 
    {
        currentAmmo = maxAmmo;
        
        gunGFX = GunGFX.instance;
    }

    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    void Update()
    {

        if (isReloading) {
            return;
        }
 
        if (currentAmmo <= 0 || (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo)) 
        {
            StartCoroutine(Reload());
            return;
        }

        // Input.GetButton("Fire1")
        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

        ammoDisplay.text = currentAmmo.ToString();
        
    }

    IEnumerator Reload() 
    {
        isReloading = true;

        if (reloadVFX != null)
        {
            reloadVFX.Play();
        }

        Debug.Log("Reloading...");

        animator.SetBool("Reloading", true);
        
        yield return new WaitForSeconds(reloadTime - 0.25f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(0.25f);

        currentAmmo = maxAmmo;
        isReloading = false;
    }

    void Shoot() 
    {
        gunGFX.ShootGunGFX();

        if (shootVFX != null)
        {
            shootVFX.Play();
        }

        currentAmmo--;

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();

            if (target != null) 
            {
                target.TakeDamage(damage);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 0.2f);
        }
    }
}
