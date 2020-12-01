using UnityEngine;
using UnityEngine.UI;

public class ItemShop : MonoBehaviour
{
    public Text money;
    public Text itemName;
    public Text itemDescription;
    public Text itemCost;
    public Button purchaseItem;

    public Button[] itemButtons;
    public int selectedItem = 0;

    public void Start()
    {
        this.money.text = "$" + Player.playerInstance.money;
    }

    public void SetSelected(int selection)
    {
        this.selectedItem = selection;
    }
    public void DisplayItem(int item)
    { 
        Item purchase;

        switch (item)
        {
            case 0:
                purchase = new SlowGun();
                break;
            case 1:
                purchase = new RandomGun();
                break;
            case 2:
                purchase = new HandCannon();
                break;
            case 3:
                purchase = new AssaultRifle();
                break;
            case 4:
                purchase = new Dash(Player.playerInstance);
                break;
            case 5:
                purchase = new Knockback(Player.playerInstance);
                break;
            case 6:
                purchase = new Invisible(Player.playerInstance);
                break;
            case 7:
                purchase = new Shield(Player.playerInstance);
                break;
            case 8:
                purchase = new DamageBoost();
                break;
            case 9:
                purchase = new HealthBoost();
                break;
            case 10:
                purchase = new CritBoost();
                break;
            case 11:
                purchase = new SpeedBoost();
                break;
            case 12:
                purchase = new JumpBoost();
                break;
            case 13:
                purchase = new DamageResistance();
                break;
            case 14:
                purchase = new HealthRegen();
                break;
            case 15:
                purchase = new TeddyBear();
                break;
            default:
                purchase = new PassiveItem();
                break;             
        }
        
       
        itemName.gameObject.SetActive(true);
        itemName.text = purchase.itemName;

        itemCost.gameObject.SetActive(true);
        itemCost.text = "$" + purchase.cost;

        itemDescription.text = purchase.description;

        purchaseItem.gameObject.SetActive(true);
    }

    public void PurchaseItem()
    {
        Item purchase;

        switch (this.selectedItem)
        {
            case 0:
                purchase = new SlowGun();
                if (purchase.cost <= Player.playerInstance.money)
                {
                    this.itemButtons[selectedItem].gameObject.SetActive(false);
                    this.itemDescription.text = "Click on an item to get information about it and purchase it.";
                    this.purchaseItem.gameObject.SetActive(false);
                    this.itemName.gameObject.SetActive(false);
                    this.itemCost.gameObject.SetActive(false);
                    Player.playerInstance.money -= purchase.cost;
                    Player.playerInstance.activeItems[0] = (SlowGun) purchase;
                }
                break;
            case 1:
                purchase = new RandomGun();
                if (purchase.cost <= Player.playerInstance.money)
                {
                    this.itemButtons[selectedItem].gameObject.SetActive(false);
                    this.itemDescription.text = "Click on an item to get information about it and purchase it.";
                    this.purchaseItem.gameObject.SetActive(false);
                    this.itemName.gameObject.SetActive(false);
                    this.itemCost.gameObject.SetActive(false);
                    Player.playerInstance.money -= purchase.cost;
                    Player.playerInstance.activeItems[0] = (RandomGun)purchase;
                }
                break;
            case 2:
                purchase = new HandCannon();
                if (purchase.cost <= Player.playerInstance.money)
                {
                    this.itemButtons[selectedItem].gameObject.SetActive(false);
                    this.itemDescription.text = "Click on an item to get information about it and purchase it.";
                    this.purchaseItem.gameObject.SetActive(false);
                    this.itemName.gameObject.SetActive(false);
                    this.itemCost.gameObject.SetActive(false);
                    Player.playerInstance.money -= purchase.cost;
                    Player.playerInstance.activeItems[0] = (HandCannon)purchase;
                }
                break;
            case 3:
                purchase = new AssaultRifle();
                if (purchase.cost <= Player.playerInstance.money)
                {
                    this.itemButtons[selectedItem].gameObject.SetActive(false);
                    this.itemDescription.text = "Click on an item to get information about it and purchase it.";
                    this.purchaseItem.gameObject.SetActive(false);
                    this.itemName.gameObject.SetActive(false);
                    this.itemCost.gameObject.SetActive(false);
                    Player.playerInstance.money -= purchase.cost;
                    Player.playerInstance.activeItems[0] = (AssaultRifle)purchase;
                }
                break;
            case 4:
                purchase = new Dash(Player.playerInstance);
                if (purchase.cost <= Player.playerInstance.money)
                {
                    this.itemButtons[selectedItem].gameObject.SetActive(false);
                    this.itemDescription.text = "Click on an item to get information about it and purchase it.";
                    this.purchaseItem.gameObject.SetActive(false);
                    this.itemName.gameObject.SetActive(false);
                    this.itemCost.gameObject.SetActive(false);
                    Player.playerInstance.money -= purchase.cost;
                    Player.playerInstance.secondaryItem = (Dash)purchase;
                }
                break;
            case 5:
                purchase = new Knockback(Player.playerInstance);
                if (purchase.cost <= Player.playerInstance.money)
                {
                    this.itemButtons[selectedItem].gameObject.SetActive(false);
                    this.itemDescription.text = "Click on an item to get information about it and purchase it.";
                    this.purchaseItem.gameObject.SetActive(false);
                    this.itemName.gameObject.SetActive(false);
                    this.itemCost.gameObject.SetActive(false);
                    Player.playerInstance.money -= purchase.cost;
                    Player.playerInstance.secondaryItem = (Knockback) purchase;
                }
                break;
            case 6:
                purchase = new Invisible(Player.playerInstance);
                if (purchase.cost <= Player.playerInstance.money)
                {
                    this.itemButtons[selectedItem].gameObject.SetActive(false);
                    this.itemDescription.text = "Click on an item to get information about it and purchase it.";
                    this.purchaseItem.gameObject.SetActive(false);
                    this.itemName.gameObject.SetActive(false);
                    this.itemCost.gameObject.SetActive(false);
                    Player.playerInstance.money -= purchase.cost;
                    Player.playerInstance.secondaryItem = (Invisible)purchase;
                }
                break;
            case 7:
                purchase = new Shield(Player.playerInstance);
                if (purchase.cost <= Player.playerInstance.money)
                {
                    this.itemButtons[selectedItem].gameObject.SetActive(false);
                    this.itemDescription.text = "Click on an item to get information about it and purchase it.";
                    this.purchaseItem.gameObject.SetActive(false);
                    this.itemName.gameObject.SetActive(false);
                    this.itemCost.gameObject.SetActive(false);
                    Player.playerInstance.money -= purchase.cost;
                    Player.playerInstance.secondaryItem = (Shield)purchase;
                }
                break;
            case 8:
                purchase = new DamageBoost();
                if (purchase.cost <= Player.playerInstance.money)
                {
                    this.itemButtons[selectedItem].gameObject.SetActive(false);
                    this.itemDescription.text = "Click on an item to get information about it and purchase it.";
                    this.purchaseItem.gameObject.SetActive(false);
                    this.itemName.gameObject.SetActive(false);
                    this.itemCost.gameObject.SetActive(false);
                    DamageBoost db = (DamageBoost) purchase;
                    Player.playerInstance.money -= purchase.cost;
                    db.ApplyBonus(Player.playerInstance);
                }
                break;
            case 9:
                purchase = new HealthBoost();
                if (purchase.cost <= Player.playerInstance.money)
                {
                    this.itemButtons[selectedItem].gameObject.SetActive(false);
                    this.itemDescription.text = "Click on an item to get information about it and purchase it.";
                    this.purchaseItem.gameObject.SetActive(false);
                    this.itemName.gameObject.SetActive(false);
                    this.itemCost.gameObject.SetActive(false);
                    HealthBoost item = (HealthBoost)purchase;
                    Player.playerInstance.money -= purchase.cost;
                    item.ApplyBonus(Player.playerInstance);
                }
                break;
            case 10:
                purchase = new CritBoost();
                if (purchase.cost <= Player.playerInstance.money)
                {
                    this.itemButtons[selectedItem].gameObject.SetActive(false);
                    this.itemDescription.text = "Click on an item to get information about it and purchase it.";
                    this.purchaseItem.gameObject.SetActive(false);
                    this.itemName.gameObject.SetActive(false);
                    this.itemCost.gameObject.SetActive(false);
                    CritBoost item = (CritBoost)purchase;
                    Player.playerInstance.money -= purchase.cost;
                    item.ApplyBonus(Player.playerInstance);
                }
                break;
            case 11:
                purchase = new SpeedBoost();
                if (purchase.cost <= Player.playerInstance.money)
                {
                    this.itemButtons[selectedItem].gameObject.SetActive(false);
                    this.itemDescription.text = "Click on an item to get information about it and purchase it.";
                    this.purchaseItem.gameObject.SetActive(false);
                    this.itemName.gameObject.SetActive(false);
                    this.itemCost.gameObject.SetActive(false);
                    SpeedBoost item = (SpeedBoost)purchase;
                    Player.playerInstance.money -= purchase.cost;
                    item.ApplyBonus(Player.playerInstance);
                }
                break;
            case 12:
                purchase = new JumpBoost();
                if (purchase.cost <= Player.playerInstance.money)
                {
                    this.itemButtons[selectedItem].gameObject.SetActive(false);
                    this.itemDescription.text = "Click on an item to get information about it and purchase it.";
                    this.purchaseItem.gameObject.SetActive(false);
                    this.itemName.gameObject.SetActive(false);
                    this.itemCost.gameObject.SetActive(false);
                    JumpBoost item = (JumpBoost)purchase;
                    Player.playerInstance.money -= purchase.cost;
                    item.ApplyBonus(Player.playerInstance);
                }
                break;
            case 13:
                purchase = new DamageResistance();
                if (purchase.cost <= Player.playerInstance.money)
                {
                    this.itemButtons[selectedItem].gameObject.SetActive(false);
                    this.itemDescription.text = "Click on an item to get information about it and purchase it.";
                    this.purchaseItem.gameObject.SetActive(false);
                    this.itemName.gameObject.SetActive(false);
                    this.itemCost.gameObject.SetActive(false);
                    DamageResistance item = (DamageResistance)purchase;
                    Player.playerInstance.money -= purchase.cost;
                    item.ApplyBonus(Player.playerInstance);
                }
                break;
            case 14:
                purchase = new HealthRegen();
                if (purchase.cost <= Player.playerInstance.money)
                {
                    this.itemButtons[selectedItem].gameObject.SetActive(false);
                    this.itemDescription.text = "Click on an item to get information about it and purchase it.";
                    this.purchaseItem.gameObject.SetActive(false);
                    this.itemName.gameObject.SetActive(false);
                    this.itemCost.gameObject.SetActive(false);
                    HealthRegen item = (HealthRegen)purchase;
                    Player.playerInstance.money -= purchase.cost;
                    item.ApplyBonus(Player.playerInstance);
                }
                break;
            case 15:
                purchase = new TeddyBear();
                if (purchase.cost <= Player.playerInstance.money)
                {
                    this.itemButtons[selectedItem].gameObject.SetActive(false);
                    this.itemDescription.text = "Click on an item to get information about it and purchase it.";
                    this.purchaseItem.gameObject.SetActive(false);
                    this.itemName.gameObject.SetActive(false);
                    this.itemCost.gameObject.SetActive(false);
                    TeddyBear item = (TeddyBear)purchase;
                    Player.playerInstance.money -= purchase.cost;
                    item.ApplyBonus(Player.playerInstance);
                }
                break;
            default:
                purchase = new PassiveItem();
                break;
        }

        this.money.text = "$" + Player.playerInstance.money;
    }
}
