using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class ItemShop : MonoBehaviour
{
    public Text money;
    public Text itemName;
    public Text itemDescription;
    public Text itemCost;

    public Button purchaseItem;

    public Image[] buttonImages;
    public Sprite[] itemSprites;
    public Button[] itemButtons;

    public int[] buttonChoices;

    public int selectedItem = 0;
    public int selectedButton = 0;

    public System.Random rand = new System.Random();
    public List<int> itemShopOptions = new List<int>();

    public void Start()
    {
        this.PopulateItemShop();

        this.money.text = "$" + Player.playerInstance.money;
    
        if (GameTimer.nextStage == 4)
        {
            PopupManager.instance.queuePopup(8f, "Elizabeth", "Hey Patrick, you made it to the elevator. Great. Let's get to work. These drones are only gonna get stronger the longer we're here.", GameTimer._instance.girlTalkSprite, true);
            PopupManager.instance.queuePopup(8f, "Elizabeth", "We're gonna need to improve your cybernetics. Using scrap you've collected I can guide you. What do you want to improve?", GameTimer._instance.girlTalkSprite);
        }
        else if (GameTimer.nextStage == 7)
        {
            //PopupManager.instance.queuePopup(8f, "Elizabeth", "after workshop, next stage is lab", GameTimer._instance.girlTalkSprite);
            PopupManager.instance.queuePopup(8f, "Elizabeth", "You're starting to get the hang of things. I've got some important info to pass on to you. Our scanners have detected something on the roof.", GameTimer._instance.girlTalkSprite, true);
            PopupManager.instance.queuePopup(8f, "Elizabeth", "It looks like there's some large cybernetic weapon on the rooftops... It may have flight capacity. Be careful.", GameTimer._instance.girlTalkSprite);

        }
        else if (GameTimer.nextStage == 8)
        {
            //PopupManager.instance.queuePopup(8f, "Elizabeth", "after lab, next is boss", GameTimer._instance.girlTalkSprite);
            PopupManager.instance.queuePopup(8f, "Elizabeth", "This elevator should take you right up to the rooftops. Be careful, it looks like Crowe himself is in the machine... whatever it is.", GameTimer._instance.girlTalkSprite, true);
            PopupManager.instance.queuePopup(8f, "Elizabeth", "This is your chance to get revenge on that son of a bitch. Good luck.", GameTimer._instance.girlTalkSprite);
        }
    }

    public void PopulateItemShop()
    {
        this.AssignItem(0, this.GetUniqueRandom(0, 4));
        this.AssignItem(1, this.GetUniqueRandom(0, 4));
        this.AssignItem(2, this.GetUniqueRandom(4, 8));
        this.AssignItem(3, this.GetUniqueRandom(4, 8));
        this.AssignItem(4, this.GetUniqueRandom(8, 16));
        this.AssignItem(5, this.GetUniqueRandom(8, 16));
        this.AssignItem(6, this.GetUniqueRandom(8, 16));
        this.AssignItem(7, this.GetUniqueRandom(8, 16));
    }

    public int GetUniqueRandom(int min, int max)
    {
        int possibleUnique = this.rand.Next(min, max);

        while (this.itemShopOptions.Contains(possibleUnique))
        {
            possibleUnique = this.rand.Next(min, max);
        }

        this.itemShopOptions.Add(possibleUnique);
        return possibleUnique;
    }

    public void AssignItem(int button, int item)
    {
        this.buttonImages[button].sprite = this.itemSprites[item];
        this.buttonChoices[button] = item;
    }

    public void SetItemSelected(int selection)
    {
        this.selectedItem = selection;
    }

    public void HealPlayer()
    {
        Player.playerInstance.Heal(Player.playerInstance.maxHealth - Player.playerInstance.health);
    }

    public void DisplayItem(int button)
    {
        Item purchase;
        this.selectedButton = button;
        this.selectedItem = buttonChoices[this.selectedButton];

        switch (this.buttonChoices[button])
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
                purchase = new Heal(Player.playerInstance);
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
                    this.itemDescription.text = "Click on an item to get information about it and purchase it.";
                    this.purchaseItem.gameObject.SetActive(false);
                    this.itemName.gameObject.SetActive(false);
                    this.itemCost.gameObject.SetActive(false);
                    Player.playerInstance.money -= purchase.cost;
                    Player.playerInstance.activeItems[0] = (SlowGun)purchase;
                    this.itemButtons[this.selectedButton].gameObject.SetActive(false);
                }
                break;
            case 1:
                purchase = new RandomGun();
                if (purchase.cost <= Player.playerInstance.money)
                {
                    this.itemDescription.text = "Click on an item to get information about it and purchase it.";
                    this.purchaseItem.gameObject.SetActive(false);
                    this.itemName.gameObject.SetActive(false);
                    this.itemCost.gameObject.SetActive(false);
                    Player.playerInstance.money -= purchase.cost;
                    Player.playerInstance.activeItems[0] = (RandomGun)purchase;
                    this.itemButtons[this.selectedButton].gameObject.SetActive(false);
                }
                break;
            case 2:
                purchase = new HandCannon();
                if (purchase.cost <= Player.playerInstance.money)
                {
                    this.itemDescription.text = "Click on an item to get information about it and purchase it.";
                    this.purchaseItem.gameObject.SetActive(false);
                    this.itemName.gameObject.SetActive(false);
                    this.itemCost.gameObject.SetActive(false);
                    Player.playerInstance.money -= purchase.cost;
                    Player.playerInstance.activeItems[0] = (HandCannon)purchase;
                    this.itemButtons[this.selectedButton].gameObject.SetActive(false);
                }
                break;
            case 3:
                purchase = new AssaultRifle();
                if (purchase.cost <= Player.playerInstance.money)
                {
                    this.itemDescription.text = "Click on an item to get information about it and purchase it.";
                    this.purchaseItem.gameObject.SetActive(false);
                    this.itemName.gameObject.SetActive(false);
                    this.itemCost.gameObject.SetActive(false);
                    Player.playerInstance.money -= purchase.cost;
                    Player.playerInstance.activeItems[0] = (AssaultRifle)purchase;
                    this.itemButtons[this.selectedButton].gameObject.SetActive(false);
                }
                break;
            case 4:
                purchase = new Heal(Player.playerInstance);
                if (purchase.cost <= Player.playerInstance.money)
                {
                    this.itemDescription.text = "Click on an item to get information about it and purchase it.";
                    this.purchaseItem.gameObject.SetActive(false);
                    this.itemName.gameObject.SetActive(false);
                    this.itemCost.gameObject.SetActive(false);
                    Player.playerInstance.money -= purchase.cost;
                    Player.playerInstance.secondaryItem = (Heal)purchase;
                    this.itemButtons[this.selectedButton].gameObject.SetActive(false);
                }
                break;
            case 5:
                purchase = new Knockback(Player.playerInstance);
                if (purchase.cost <= Player.playerInstance.money)
                {
                    this.itemDescription.text = "Click on an item to get information about it and purchase it.";
                    this.purchaseItem.gameObject.SetActive(false);
                    this.itemName.gameObject.SetActive(false);
                    this.itemCost.gameObject.SetActive(false);
                    Player.playerInstance.money -= purchase.cost;
                    Player.playerInstance.secondaryItem = (Knockback) purchase;
                    this.itemButtons[this.selectedButton].gameObject.SetActive(false);
                }
                break;
            case 6:
                purchase = new Invisible(Player.playerInstance);
                if (purchase.cost <= Player.playerInstance.money)
                {
                    this.itemDescription.text = "Click on an item to get information about it and purchase it.";
                    this.purchaseItem.gameObject.SetActive(false);
                    this.itemName.gameObject.SetActive(false);
                    this.itemCost.gameObject.SetActive(false);
                    Player.playerInstance.money -= purchase.cost;
                    Player.playerInstance.secondaryItem = (Invisible)purchase;
                    this.itemButtons[this.selectedButton].gameObject.SetActive(false);
                }
                break;
            case 7:
                purchase = new Shield(Player.playerInstance);
                if (purchase.cost <= Player.playerInstance.money)
                {
                    this.itemDescription.text = "Click on an item to get information about it and purchase it.";
                    this.purchaseItem.gameObject.SetActive(false);
                    this.itemName.gameObject.SetActive(false);
                    this.itemCost.gameObject.SetActive(false);
                    Player.playerInstance.money -= purchase.cost;
                    Player.playerInstance.secondaryItem = (Shield)purchase;
                    this.itemButtons[this.selectedButton].gameObject.SetActive(false);
                }
                break;
            case 8:
                purchase = new DamageBoost();
                if (purchase.cost <= Player.playerInstance.money)
                {
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
