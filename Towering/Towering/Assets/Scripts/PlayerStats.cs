using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
    public float damageUpgrades = 1f;
    public float rangeUpgrades = 1f;
    public float fireRateUpgrades = 1f;
    public float towerHealthUpgrades = 1f;

    [HideInInspector]
    public static float damage;
    public static float range;
    public static float fireRate;
    public static float damageLevel;
    public static float rangeLevel;
    public static float fireRateLevel;
    public static float towerHealthLevel;

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
		Cubes = startCubes;
        Gems = startGems;
		towerHP = startTowerHP;
        damage = startDamage;
        range = startRange;
        fireRate = startFireRate;

        damageLevel = damageUpgrades;
        rangeLevel = rangeUpgrades;
        fireRateLevel = fireRateUpgrades;
        towerHealthLevel = towerHealthUpgrades;
	}

    public void Reset ()
    {
        Cubes = startCubes;
        // Do not reset Gems
		towerHP = instance.startTowerHP;
        damage = instance.startDamage;
        range = instance.startRange;
        fireRate = instance.startFireRate;

        damageLevel = instance.damageUpgrades;
        rangeLevel = instance.rangeUpgrades;
        fireRateLevel = instance.fireRateUpgrades;
        towerHealthLevel = instance.towerHealthUpgrades;
    }

    void OnEnable ()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "InGame")
        {
            gameObject.SetActive(true);
            Reset();
        }
    }
}
