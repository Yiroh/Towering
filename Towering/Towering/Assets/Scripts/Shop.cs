using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    [Header("Text")]
    public GameObject UpgradesPanel;
    public TMP_Text damageText;
    public TMP_Text fireRateText;
    public TMP_Text rangeText;
    public TMP_Text towerHealthText;

    [Header("Buttons")]
    public Button damageButton;
    public Button fireRateButton;
    public Button rangeButton;
    public Button towerHealthButton;

    public float damageCost = Mathf.Round(((1 * PlayerStats.damageLevel) + 2) / 2);
    public float fireRateCost = Mathf.Round(((1.5f * PlayerStats.fireRateLevel) + 2) / 2);
    public float rangeCost = Mathf.Round(((2 * PlayerStats.rangeLevel) + 2) / 2);
    public float towerHealthCost = Mathf.Round(((1 * PlayerStats.towerHealthLevel) + 2) / 2);

    void Start ()
    {
        damageText.text = Mathf.Round(PlayerStats.damage).ToString() + " --> " + Mathf.Round(PlayerStats.damage + (1 * PlayerStats.damageLevel)).ToString();
        fireRateText.text = (Mathf.Round(PlayerStats.fireRate * 10) / 10.0).ToString() + " --> " + (Mathf.Round((PlayerStats.fireRate + 0.1f) * 10) / 10.0).ToString();
        rangeText.text = (Mathf.Round(PlayerStats.range * 10) / 10.0).ToString() + " --> " + (Mathf.Round((PlayerStats.range + 0.5f) * 10) / 10.0).ToString();
        towerHealthText.text = Mathf.Round(PlayerStats.towerHP).ToString() + " --> " + Mathf.Round(PlayerStats.towerHP + (1 * PlayerStats.towerHealthLevel)).ToString();
    }

    void Update ()
    {
        // Enable or disable buttons depending on cost
        if( PlayerStats.Cubes < damageCost)
            damageButton.interactable = false;
        else
            damageButton.interactable = true;

        if (PlayerStats.Cubes < fireRateCost)
            fireRateButton.interactable = false;
        else if (PlayerStats.Cubes >= fireRateCost && PlayerStats.fireRate < 10f)
            fireRateButton.interactable = true;

        if (PlayerStats.Cubes < rangeCost || PlayerStats.range > 20f)
            rangeButton.interactable = false;
        else
            rangeButton.interactable = true;

        if (PlayerStats.Cubes < towerHealthCost)
            towerHealthButton.interactable = false;
        else
            towerHealthButton.interactable = true;
    }

    public void PurchaseUpgrades ()
    {
        if (UpgradesPanel != null)
        {
            UpgradesPanel.SetActive(true);
        }
    }

    public void CloseUpgrades ()
    {
        if (UpgradesPanel != null)
        {
            UpgradesPanel.SetActive(false);
        }
    }

    public void PurchaseDamage ()
    {
        PlayerStats.damage = PlayerStats.damage + (1 * PlayerStats.damageLevel);
        PlayerStats.damageLevel++;
        PlayerStats.Cubes -= damageCost;
        damageCost = Mathf.Round(((1 * PlayerStats.damageLevel) + 2) / 2);
        damageText.text = Mathf.Round(PlayerStats.damage).ToString() + " --> " + Mathf.Round(PlayerStats.damage + (1 * PlayerStats.damageLevel)).ToString();
    }

    public void PurchaseFireRate ()
    {
        PlayerStats.fireRate = PlayerStats.fireRate + 0.1f;
        PlayerStats.fireRateLevel++;
        PlayerStats.Cubes -= fireRateCost;
        fireRateCost = Mathf.Round(((2 * PlayerStats.fireRateLevel) + 2) / 2);
        fireRateText.text = (Mathf.Round(PlayerStats.fireRate * 10) / 10.0).ToString() + " --> " + (Mathf.Round((PlayerStats.fireRate + 0.1f) * 10) / 10.0).ToString();
    }

    public void PurchaseRange ()
    {
        PlayerStats.range = PlayerStats.range + 0.5f;
        PlayerStats.rangeLevel++;
        PlayerStats.Cubes -= rangeCost;
        rangeCost = Mathf.Round(((2 * PlayerStats.rangeLevel) + 2) / 2);
        rangeText.text = (Mathf.Round(PlayerStats.range * 10) / 10.0).ToString() + " --> " + (Mathf.Round((PlayerStats.range + 0.5f) * 10) / 10.0).ToString();
    }

    public void PurchaseTowerHP ()
    {
        PlayerStats.towerHP = PlayerStats.towerHP + (1 * PlayerStats.towerHealthLevel);
        PlayerStats.towerHealthLevel++;
        PlayerStats.Cubes -= towerHealthCost;
        towerHealthCost = Mathf.Round(((1 * PlayerStats.towerHealthLevel) + 2) / 2);
        towerHealthText.text = Mathf.Round(PlayerStats.towerHP).ToString() + " --> " + Mathf.Round(PlayerStats.towerHP + (1 * PlayerStats.towerHealthLevel)).ToString();

    }

    public void ResetShop ()
    {
        damageCost = 2f;
        fireRateCost = 2f;
        damageText.text = PlayerStats.damage.ToString() + " --> " + (PlayerStats.damage + (1 * PlayerStats.damageLevel)).ToString();
        fireRateText.text = (Mathf.Round(PlayerStats.fireRate * 10) / 10.0).ToString() + " --> " + (Mathf.Round((PlayerStats.fireRate + 0.1f) * 10) / 10.0).ToString();
        rangeText.text = (Mathf.Round(PlayerStats.range * 10) / 10.0).ToString() + " --> " + (Mathf.Round((PlayerStats.range + 0.5f) * 10) / 10.0).ToString();
        towerHealthText.text = Mathf.Round(PlayerStats.towerHP).ToString() + " --> " + Mathf.Round(PlayerStats.towerHP + (1 * PlayerStats.towerHealthLevel)).ToString();
    }
}
