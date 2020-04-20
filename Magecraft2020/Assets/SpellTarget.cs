using UnityEngine;

public class SpellTarget : MonoBehaviour
{
    public float health = 50f;
    public GameObject destructed;

    public void TakeDamage (float amount)
    {
        health -= amount;
        
        
        if (health <= 0f)
        {
            Die();
            //I really think this one is self explanatory
        }
    }
    void Die()
    {
        
        Instantiate(destructed, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    //so this only happens if the target hits less than zero hp, but it will instantiate the broken version of the object, and remove the normal version.
    //this gives the boxes the destructible effect
}
