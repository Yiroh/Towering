using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Workshop : MonoBehaviour
{
    public GameObject UpgradesPanel;
    public TMP_Text damageText;
    public TMP_Text fireRateText;

    public Button damageButton;
    public Button fireRateButton;

    public float damageCost = Mathf.Round(((1 * PlayerStats.damageUpgrades) + 2) / 2);
    public float fireRateCost = Mathf.Round(((1 * PlayerStats.fireRateUpgrades) + 2) / 2);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        damageText.text = PlayerStats.damage.ToString() + " --> " + (PlayerStats.damage + (1 * PlayerStats.damageUpgrades)).ToString();
        fireRateText.text = PlayerStats.fireRate.ToString() + " --> " + (PlayerStats.fireRate + 0.1f).ToString();
    }

    void Update ()
    {
        // Enable or disable buttons depending on cost
        if(PlayerStats.Money < damageCost)
            damageButton.interactable = false;
        else
            damageButton.interactable = true;

        if(PlayerStats.Money < fireRateCost)
            fireRateButton.interactable = false;
        else if (PlayerStats.Money >= fireRateCost && PlayerStats.fireRate < 10f)
            fireRateButton.interactable = true;
    }

    public void PurchaseDamage ()
    {
        PlayerStats.startDamage = PlayerStats.startDamage + (1 * PlayerStats.damageUpgrades);
        PlayerStats.damageUpgrades++;
        PlayerStats.Money -= damageCost;
        damageCost = Mathf.Round(((1 * PlayerStats.damageUpgrades) + 2) / 2);
        damageText.text = PlayerStats.startDamage.ToString() + " --> " + (PlayerStats.startDamage + (1 * PlayerStats.damageUpgrades)).ToString();
    }

    public void PurchaseFireRate ()
    {
        PlayerStats.startFireRate = PlayerStats.startFireRate + 0.1f;
        PlayerStats.fireRateUpgrades++;
        PlayerStats.Money -= fireRateCost;
        fireRateCost = Mathf.Round(((2 * PlayerStats.fireRateUpgrades) + 2) / 2);
        fireRateText.text = PlayerStats.startFireRate.ToString() + " --> " + (PlayerStats.startFireRate + 0.1f).ToString();
        if(PlayerStats.startFireRate >= 10f)
        {
            fireRateButton.interactable = false;
        }
    }
}
