
using UnityEngine;

public class Target : MonoBehaviour {

    public float health = 50f;

    public void TakeDamage(float amount)
    {
        health -= amount;

        if(health <= 0f)
        {
            //dies
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);

    }
}
