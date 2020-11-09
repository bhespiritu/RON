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

        if (item >= 990)
        {
            item -= 990;

            switch (item)
            {
                case 0:
                    purchase = new HealthBoost();
                    break;
                case 1:
                    purchase = new DamageBoost();
                    break;
                default:
                    purchase = new PassiveItem();
                    break;
            }
        }
        else
        {
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
                default:
                    purchase = new BaseGun();
                    break;
            }
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
                DamageBoost db = new DamageBoost();
                if (db.cost <= Player.playerInstance.money)
                {
                    this.itemButtons[selectedItem].gameObject.SetActive(false);
                    this.itemDescription.text = "Click on an item to get information about it and purchase it.";
                    this.purchaseItem.gameObject.SetActive(false);
                    this.itemName.gameObject.SetActive(false);
                    this.itemCost.gameObject.SetActive(false);
                    Player.playerInstance.money -= db.cost;
                    db.ApplyBonus(Player.playerInstance);
                }
                break;
            case 5:
                HealthBoost hb = new HealthBoost();
                if (hb.cost <= Player.playerInstance.money)
                {
                    this.itemButtons[selectedItem].gameObject.SetActive(false);
                    this.itemDescription.text = "Click on an item to get information about it and purchase it.";
                    this.purchaseItem.gameObject.SetActive(false);
                    this.itemName.gameObject.SetActive(false);
                    this.itemCost.gameObject.SetActive(false);
                    Player.playerInstance.money -= hb.cost;
                    hb.ApplyBonus(Player.playerInstance);
                }
                break;
            default:
                purchase = new PassiveItem();
                break;
        }

        this.money.text = "$" + Player.playerInstance.money;
    }
}
