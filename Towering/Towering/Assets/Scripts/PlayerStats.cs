using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour 
{
    public static PlayerStats instance;

	public static float Cubes; // Temporary upgrade currency
	public float startCubes = 0;

    public static float Gems; // Permanent Upgrade currency
    public float startGems = 0;

	public static float towerHP;
	public float startTowerHP = 20f;

	public static int Rounds;

    [Header("Attributes")]
    public float startDamage = 5f;
    public float startRange = 10f;
    public float startFireRate = 1f;
    public static float damageUpgrades;
    public static float rangeUpgrades;
    public static float fireRateUpgrades;

    [HideInInspector]
    public static float damage;
    public static float range;
    public static float fireRate;
    public static float damageLevel;
    public static float rangeLevel;
    public static float fireRateLevel;

    void Awake ()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }	
    }

	void Start ()
	{
        damageUpgrades = 1f;
        rangeUpgrades = 1f;
        fireRateUpgrades = 1f;

		Cubes = startCubes;
        Gems = startGems;
		towerHP = startTowerHP;
        damage = startDamage;
        range = startRange;
        fireRate = startFireRate;

        damageLevel = damageUpgrades;
        rangeLevel = rangeUpgrades;
        fireRateLevel = fireRateUpgrades;
	}

    public void Reset ()
    {
        Cubes = startCubes;
        // Do not reset Gems
		towerHP = startTowerHP;
        damage = startDamage;
        range = startRange;
        fireRate = startFireRate;

        damageLevel = damageUpgrades;
        rangeLevel = rangeUpgrades;
        fireRateLevel = fireRateUpgrades;
    }
}
