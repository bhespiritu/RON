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
    	return this.item;
    }
}