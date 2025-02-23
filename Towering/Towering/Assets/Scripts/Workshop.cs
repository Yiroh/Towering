using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Workshop : MonoBehaviour
{
    [Header("Text")]
    public TMP_Text damageText;
    public TMP_Text fireRateText;
    public TMP_Text rangeText;
    public TMP_Text towerHealthText;
    public TMP_Text gemsText;

    [Header("Buttons")]
    public Button damageButton;
    public Button fireRateButton;
    public Button rangeButton;
    public Button towerHealthButton;

    [Header("Costs")]
    public float damageCost;
    public float fireRateCost;
    public float rangeCost;
    public float towerHealthCost;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(PlayerStats.instance != null)
        {
            damageCost = Mathf.Round(((1 * PlayerStats.instance.damageUpgrades) + 2) / 2);
            fireRateCost = Mathf.Round(((1.5f * PlayerStats.instance.fireRateUpgrades) + 2) / 2);
            rangeCost = Mathf.Round(((2 * PlayerStats.instance.rangeUpgrades) + 2) / 2);
            towerHealthCost = Mathf.Round(((1 * PlayerStats.instance.towerHealthUpgrades) + 2) / 2);

            damageText.text = PlayerStats.instance.startDamage.ToString() + " --> " + (PlayerStats.instance.startDamage + (1 * PlayerStats.instance.damageUpgrades)).ToString();
            fireRateText.text = PlayerStats.instance.startFireRate.ToString() + " --> " + (PlayerStats.instance.startFireRate + 0.1f).ToString();
            rangeText.text = (Mathf.Round(PlayerStats.instance.startRange * 10) / 10.0).ToString() + " --> " + (Mathf.Round((PlayerStats.instance.startRange + 0.5f) * 10) / 10.0).ToString();
            towerHealthText.text = Mathf.Round(PlayerStats.instance.startTowerHP).ToString() + " --> " + Mathf.Round(PlayerStats.instance.startTowerHP + (1 * PlayerStats.instance.towerHealthUpgrades)).ToString();
        }
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

        if (PlayerStats.Gems < rangeCost || PlayerStats.instance.startRange > 20f)
            rangeButton.interactable = false;
        else
            rangeButton.interactable = true;

        if (PlayerStats.Gems < towerHealthCost)
            towerHealthButton.interactable = false;
        else
            towerHealthButton.interactable = true;

        gemsText.text = "Gems: " + PlayerStats.Gems.ToString();
    }

    public void PurchaseDamage ()
    {
        PlayerStats.instance.startDamage = PlayerStats.instance.startDamage + (1 * PlayerStats.instance.damageUpgrades);
        PlayerStats.instance.damageUpgrades++;
        PlayerStats.Gems -= damageCost;
        damageCost = Mathf.Round(((1 * PlayerStats.instance.damageUpgrades) + 2) / 2);
        damageText.text = PlayerStats.instance.startDamage.ToString() + " --> " + (PlayerStats.instance.startDamage + (1 * PlayerStats.instance.damageUpgrades)).ToString();
    }

    public void PurchaseFireRate ()
    {
        PlayerStats.instance.startFireRate = PlayerStats.instance.startFireRate + 0.1f;
        PlayerStats.instance.fireRateUpgrades++;
        PlayerStats.Gems -= fireRateCost;
        fireRateCost = Mathf.Round(((1.5f * PlayerStats.instance.fireRateUpgrades) + 2) / 2);
        fireRateText.text = PlayerStats.instance.startFireRate.ToString() + " --> " + (PlayerStats.instance.startFireRate + 0.1f).ToString();
    }

    public void PurchaseRange ()
    {
        PlayerStats.instance.startRange = PlayerStats.instance.startRange + 0.5f;
        PlayerStats.instance.fireRateUpgrades++;
        PlayerStats.Gems -= rangeCost;
        rangeCost = Mathf.Round(((2.0f * PlayerStats.instance.rangeUpgrades) + 2) / 2);
        rangeText.text = PlayerStats.instance.startRange.ToString() + " --> " + (PlayerStats.instance.startRange + 0.5f).ToString();
    }

    public void PurchaseTowerHealth ()
    {
        PlayerStats.instance.startTowerHP = PlayerStats.instance.startTowerHP + (1 * PlayerStats.instance.towerHealthUpgrades);
        PlayerStats.instance.towerHealthUpgrades++;
        PlayerStats.Gems -= towerHealthCost;
        towerHealthCost = Mathf.Round(((1 * PlayerStats.instance.towerHealthUpgrades) + 2) / 2);
        towerHealthText.text = PlayerStats.instance.startTowerHP.ToString() + " --> " + (PlayerStats.instance.startTowerHP + (1 * PlayerStats.instance.towerHealthUpgrades)).ToString();
    }
}
