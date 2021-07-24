using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage(float amount) 
    {
        health -= amount;

        if (health <= 0f) {
            Die();
        }
    }

    void Die()
    {
        if (GetComponentInParent<KillObjective>() != null) 
        {
            GetComponentInParent<KillObjective>().ConfirmKill();
        }
        Destroy(gameObject);
    }
}
