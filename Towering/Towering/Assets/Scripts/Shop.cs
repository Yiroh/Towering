using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public GameObject UpgradesPanel;
    public TMP_Text damageText;
    public TMP_Text fireRateText;

    public Button damageButton;
    public Button fireRateButton;

    public float damageCost = Mathf.Round(((1 * PlayerStats.damageLevel) + 2) / 2);
    public float fireRateCost = Mathf.Round(((1 * PlayerStats.fireRateLevel) + 2) / 2);

    void Start ()
    {
        damageText.text = Mathf.Round(PlayerStats.damage).ToString() + " --> " + Mathf.Round(PlayerStats.damage + (1 * PlayerStats.damageLevel)).ToString();
        fireRateText.text = (Mathf.Round(PlayerStats.fireRate * 10) / 10.0).ToString() + " --> " + (Mathf.Round((PlayerStats.fireRate + 0.1f) * 10) / 10.0).ToString();
    }

    void Update ()
    {
        // Enable or disable buttons depending on cost
        if(PlayerStats.Cubes < damageCost)
            damageButton.interactable = false;
        else
            damageButton.interactable = true;

        if(PlayerStats.Cubes < fireRateCost)
            fireRateButton.interactable = false;
        else if (PlayerStats.Cubes >= fireRateCost && PlayerStats.fireRate < 10f)
            fireRateButton.interactable = true;
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
        if(PlayerStats.fireRate >= 10f)
        {
            fireRateButton.interactable = false;
        }
    }

    public void ResetShop ()
    {
        damageCost = 2f;
        fireRateCost = 2f;
        damageText.text = PlayerStats.damage.ToString() + " --> " + (PlayerStats.damage + (1 * PlayerStats.damageLevel)).ToString();
        fireRateText.text = (Mathf.Round(PlayerStats.fireRate * 10) / 10.0).ToString() + " --> " + (Mathf.Round((PlayerStats.fireRate + 0.1f) * 10) / 10.0).ToString();
    }
}
