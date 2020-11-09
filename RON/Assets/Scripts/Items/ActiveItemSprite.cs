using UnityEngine;

public class ActiveItemSprite : MonoBehaviour
{

	public int itemId;
	public ActiveItem item;
	
	// Start is called before the first frame update
    void Start()
    {
    	gameObject.tag = "ActiveItem";

        switch (this.itemId)
    	{
            case 0:
                this.item = new SlowGun();
                break;
            case 1:
                this.item = new RandomGun();
                break;
            case 2:
                this.item = new HandCannon();
                break;
            case 3:
                this.item = new AssaultRifle();
                break;
            default:
                this.item = new BaseGun();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public ActiveItem PickUpItem()
    {
    	return this.item;
    }
}