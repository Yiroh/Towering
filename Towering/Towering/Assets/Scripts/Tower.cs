using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Unity Setup Fields")]
    public Transform target;
    private Enemy targetEnemy;
    public string enemyTag = "Enemy";
    public GameObject bulletPrefab;
    public Transform firePoint;

    private float fireCountdown = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start ()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget ()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= PlayerStats.range)
		{
			target = nearestEnemy.transform;
			targetEnemy = nearestEnemy.GetComponent<Enemy>();
		} else
		{
			target = null;
		}

	}

    // Update is called once per frame
    void Update ()
    {
        if (target == null)
            return;

        if (fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 2f / PlayerStats.range;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot ()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

		if (bullet != null)
			bullet.Seek(target);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Tower takes damage
            Enemy e = collision.gameObject.GetComponent<Enemy>();
            PlayerStats.towerHP -= e.damage;
            e.Die();
        }
    }

    void onDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, PlayerStats.range);
    }
}
