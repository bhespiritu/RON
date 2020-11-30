using UnityEngine;

public class PassiveItemSprite : MonoBehaviour
{

	public int itemId;
	public PassiveItem item;

	// Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "PassiveItem";
    	switch (this.itemId)
    	{
            case 0:
                this.item = new HealthBoost();
                break;
            case 1:
                this.item = new DamageBoost();
                break;
            case 2:
                this.item = new HealthRegen();
                break;
            case 3:
                this.item = new JumpBoost();
                break;
            case 4:
                this.item = new CritBoost();
                break;
            case 5:
                this.item = new SpeedBoost();
                break;
            case 6:
                this.item = new TeddyBear();
                break;
            case 7:
                this.item = new DamageResistance();
                break;
            default:
                this.item = new PassiveItem();
                break;
    	}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public PassiveItem PickUpItem()
    {
        PopupManager.instance.queuePopup(2f, "Item Picked Up", this.item.shortDescription);
    	return this.item;
    }
}