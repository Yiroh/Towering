using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Workshop : MonoBehaviour
{
    public TMP_Text damageText;
    public TMP_Text fireRateText;

    public Button damageButton;
    public Button fireRateButton;

    public float damageCost = Mathf.Round(((1 * PlayerStats.damageUpgrades) + 2) / 2);
    public float fireRateCost = Mathf.Round(((1 * PlayerStats.fireRateUpgrades) + 2) / 2);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        damageText.text = PlayerStats.instance.startDamage.ToString() + " --> " + (PlayerStats.instance.startDamage + (1 * PlayerStats.damageUpgrades)).ToString();
        fireRateText.text = PlayerStats.instance.startFireRate.ToString() + " --> " + (PlayerStats.instance.startFireRate + 0.1f).ToString();
    }

    void Update ()
    {
        // Enable or disable buttons depending on cost
        if(PlayerStats.Gems < damageCost)
            damageButton.interactable = false;
        else
            damageButton.interactable = true;

        if(PlayerStats.Gems < fireRateCost)
            fireRateButton.interactable = false;
        else if (PlayerStats.Gems >= fireRateCost && PlayerStats.instance.startFireRate < 10f)
            fireRateButton.interactable = true;
    }

    public void PurchaseDamage ()
    {
        PlayerStats.instance.startDamage = PlayerStats.instance.startDamage + (1 * PlayerStats.damageUpgrades);
        PlayerStats.damageUpgrades++;
        PlayerStats.Cubes -= damageCost;
        damageCost = Mathf.Round(((1 * PlayerStats.damageUpgrades) + 2) / 2);
        damageText.text = PlayerStats.instance.startDamage.ToString() + " --> " + (PlayerStats.instance.startDamage + (1 * PlayerStats.damageUpgrades)).ToString();
    }

    public void PurchaseFireRate ()
    {
        PlayerStats.instance.startFireRate = PlayerStats.instance.startFireRate + 0.1f;
        PlayerStats.fireRateUpgrades++;
        PlayerStats.Cubes -= fireRateCost;
        fireRateCost = Mathf.Round(((2 * PlayerStats.fireRateUpgrades) + 2) / 2);
        fireRateText.text = PlayerStats.instance.startFireRate.ToString() + " --> " + (PlayerStats.instance.startFireRate + 0.1f).ToString();
        if(PlayerStats.instance.startFireRate >= 10f)
        {
            fireRateButton.interactable = false;
        }
    }
}
