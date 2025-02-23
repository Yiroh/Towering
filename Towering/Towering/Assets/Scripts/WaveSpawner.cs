using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform[] enemyPrefabs;
    public float spawnRadius = 30f;
    public float timeBetweenWaves = 6f;

    public TMP_Text waveCountText;
    public TMP_Text enemyHealthText;
    public TMP_Text enemyAttackText;


    private float countdown;
    public float waveIndex = 0f;

    void Start ()
    {
        for (int i = 0; i < enemyPrefabs.Length; i++)
        {
            Enemy e = enemyPrefabs[i].gameObject.GetComponent<Enemy>();
            e.health = e.startHealth;
            e.damage = e.startDamage; 

            if(i == 0)
            {
                enemyHealthText.text = "Enemy Health: " + (Mathf.Round(e.health * 100) / 100.0).ToString();
                enemyAttackText.text = "Enemy Attack: " + (Mathf.Round(e.damage * 100) / 100.0).ToString();
            }
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
		}

        countdown -= Time.deltaTime;

        waveCountText.text = "Wave " + Mathf.Round(waveIndex).ToString();

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            Enemy e = enemies[i].GetComponent<Enemy>();
                
            e.health = e.startHealth + (0.5f * waveIndex);
            e.damage = e.startDamage + (0.2f * waveIndex);

            enemyHealthText.text = "Enemy Health: " + (Mathf.Round(e.health * 100) / 100.0).ToString();
            enemyAttackText.text = "Enemy Attack: " + (Mathf.Round(e.damage * 100) / 100.0).ToString();
        }
    }

    IEnumerator SpawnWave () 
    {
        waveIndex++;
        Debug.Log("Wave #: " + waveIndex);

		for (int i = 0; i < waveIndex; i++)
		{
            if(i >= 15)
            {
                break;
            }
			SpawnEnemy();
			yield return new WaitForSeconds(0.5f);
		}
        if(waveIndex % 5 == 0 && waveIndex != 0)
        {
            SpawnBoss();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy ()
	{
        // Generate a random angle in degrees (0 - 360)
        float randomAngle = Random.Range(0f, 360f);

        // Convert angle to radians and calculate spawn position
        float radians = Mathf.Deg2Rad * randomAngle;
        Vector3 spawnPosition = new Vector3(Mathf.Cos(radians), 0, Mathf.Sin(radians)) * spawnRadius;

        // Adjust spawn position based on player position
        spawnPosition += transform.position;

		Instantiate(enemyPrefabs[0], spawnPosition, Quaternion.identity);
	}

    void SpawnBoss ()
	{
        Enemy e1 = enemyPrefabs[1].gameObject.GetComponent<Enemy>();
        
        // Generate a random angle in degrees (0 - 360)
        float randomAngle = Random.Range(0f, 360f);

        // Convert angle to radians and calculate spawn position
        float radians = Mathf.Deg2Rad * randomAngle;
        Vector3 spawnPosition = new Vector3(Mathf.Cos(radians), 0, Mathf.Sin(radians)) * spawnRadius;

        // Adjust spawn position based on player position
        spawnPosition += transform.position;

		Instantiate(enemyPrefabs[1], spawnPosition, Quaternion.identity);
	}

    public void KillAllEnemies() 
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies) 
        {
            Destroy(enemy); 
        }
    }

    public void Reset ()
    {
        waveIndex = 0f;
        countdown = timeBetweenWaves;
        KillAllEnemies();

        for (int i = 0; i < enemyPrefabs.Length; i++)
        {
            Enemy e = enemyPrefabs[i].gameObject.GetComponent<Enemy>();
            e.health = e.startHealth;
            e.damage = e.startDamage; 
        }
    }
}
