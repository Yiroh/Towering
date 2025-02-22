using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform[] enemyPrefabs;
    public float spawnRadius = 30f;
    public float timeBetweenWaves = 5f;

    public TMP_Text waveCountText;

    private float countdown;
    private float waveIndex = 0f;

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
        Enemy e0 = enemyPrefabs[0].gameObject.GetComponent<Enemy>();

        // Buff up enemies based on wave
        e0.health = e0.health + (0.5f * waveIndex);
        e0.damage = e0.damage + (0.2f * waveIndex);

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
        
        // Buff up boss based on wave
        e1.health = e1.health + (1f * waveIndex);
        e1.damage = e1.damage + (0.4f * waveIndex);


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
    }
}
