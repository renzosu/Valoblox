using UnityEngine;
using UnityEngine.UI;

public class SelfTarget : MonoBehaviour
{
    public float health = 100f;
    public Text healthDisplay;

    //private float numTargets = 15f;

    public GameObject gameOverUI;

    void Start() 
    {
        gameOverUI.SetActive(false);
    }

    void Update()
    {
        healthDisplay.text = health.ToString();
    }

    public void TakeDamage(float amount) 
    {
        if (health <= 0f) 
        {
            Die();
        }
        else 
        {
            health -= amount;
        }
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        gameOverUI.SetActive(true);
        //Destroy(gameObject);
    }
}
