using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public static float Money;
	public float startMoney = 0;

	public static float towerHP;
	public float startTowerHP = 20f;

	public static int Rounds;

    [Header("Attributes")]
    public float startDamage = 5f;
    public float startRange = 10f;
    public float startFireRate = 1f;

    [HideInInspector]
    public static float damage;
    public static float range;
    public static float fireRate;
    public static float damageUpgrades = 1f;
    public static float rangeUpgrades = 1f;
    public static float fireRateUpgrades = 1f;

	void Start ()
	{
		Money = startMoney;
		towerHP = startTowerHP;
        damage = startDamage;
        range = startRange;
        fireRate = startFireRate;
	}

    public void Reset ()
    {
        Money = startMoney;
		towerHP = startTowerHP;
        damage = startDamage;
        range = startRange;
        fireRate = startFireRate;

        damageUpgrades = 1f;
        rangeUpgrades = 1f;
        fireRateUpgrades = 1f;
    }
}
