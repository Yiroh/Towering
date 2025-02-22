using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Tower;
    public GameObject Unit;
    public float startSpeed = 10f;
    public float startHealth = 5f;
    public float startDamage = 1f;
    public int value = 1;
    public GameObject deathEffect;
    public GameObject bossDeathEffect;
    [HideInInspector]
    public float speed;
    public float health;
    public float damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start ()
    {
        speed = startSpeed;
        health = startHealth;
        damage = startDamage;
    }

    // Update is called once per frame
    void Update ()
    {
        Unit.transform.position = Vector3.MoveTowards(Unit.transform.position, Tower.transform.position, speed * Time.deltaTime);
    }

    public void TakeDamage (float amount)
	{
		health -= amount;
        Debug.Log("Enemy Hit for: " + amount);

		if (health <= 0)
		{
			Die();
		}
	}

    void Die ()
	{
		PlayerStats.Money += value;

        if (deathEffect != null)
        {
            GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
        }
        else if (bossDeathEffect != null)
        {
            GameObject effect = (GameObject)Instantiate(bossDeathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
        }

		Destroy(gameObject);
	}

    public void Reset ()
    {
        speed = startSpeed;
        health = startHealth;
        damage = startDamage;
    }
}
