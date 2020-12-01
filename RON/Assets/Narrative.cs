using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 


public class Narrative : MonoBehaviour
{	private string[] story; 
	public Text t; 
	private int i;  
    // Start is called before the first frame update
    void Start()
    {
        story = new string[32] {
        				  "Around 2310, a company called Biotech International began developing complicated cyborg body enhancements beginning with advanced cybernetic organs, primarily lungs and kidneys.\n\n",
        				  "They expanded their operations to include exterior body parts, netting them huge amounts of the global market.\n\n",
        				  "They quickly began to exploit workers in developing countries to cheap out on parts and lower operation costs.\n\n",
        				  "This proved massively successful, leading to a boost in their market share which pushed them towards monopoly status.\n\n",
        				  "They began to buy up smaller specific market competitors to achieve their monopoly and engaged in many experiments with their vast amount of wealth.\n\n",
        				  "They run Biotech Labs, a Bell Labs esque super brain trust of their smartest employees, given near infinite resources and encouragement to develop freely. \n\n",
        				  "This team regularly creates new high tech cybernetic enhancements. They also experiment with all sorts of other ideas.\n\n",
        				  "Around 2338, 10 of the most well respected engineers split off from the company and formed their own, called “CyberCover.\n\n",
        				  "They were led by a team of employees, one from the lab and one from the market department, Elizabeth Ollinfaire and Patrick Shenk.\n\n",
        				  "While Biotech is a ruthless company, they had little worry that CyberCover would prove a threat, and thus didn’t feel any need to subdue it.\n\n",
        				  "Come 2341, CyberCover began to get a strong hold on one of the most essential markets: cybernetic arms.\n\n",
        				  "They were able to focus much effort on addressing the few design flaws Biotech’s arms possessed, and created a more perfect version.\n\n",
        				  "They began to sap away market share, which started to worry Biotech International. \n\n",
        				  "Ollinfaire’s increasingly elaborate technology helped this process along.\n\n",
        				  "However, Shenk’s efforts were much more visible to the higher ups at Biotech Labs...\n\n",
        				  "In 2345, Biotech CEO, Hans Crowe, decided enough was enough. \n\n",
        				  "After years of business maneuvers and backroom deals, he was unable to push CyberCover out of business.\n\n",
        				  "Instead, he decided to take things to the extreme.\n\n",
        				  "Crowe decided to assassinate Patrick Shenk.\n\n",
        				  "He sent a team of high-tech bird cyborgs, designed to blow Patrick to smitherines. They did not succeed.\n\n",
        				  "They seriously injured his extremeties, but didn’t manage to kill him.\n\n",
        				  "After recovering from the initial damage, Patrick and Elizabeth decided to develop a plan to enact revenge.\n\n",
        				  "They spent the next few years giving Patrick upgraded battle ready cybernetic enhancements and training, with the end goal of destroying the Biotech International skyscraper and in the process killing their CEO.\n\n",
        				  "==========================================================\n\n",
        				  "You are Patrick Shenk. Take revenge into your own hands and storm Biotech.\n\n",
        				  "You need to ascend to the top as soon as possible. Beware, Biotech's security gets stronger with time.\n\n",
        				  "You must go through each level, gather items and money to use on the elevator to each sucessive floor to gain enough power to defeat Biotech's ultimate machine.\n\n",
        				  "Once the machine is down, you will have crippled Biotech International.\n\n", 
        				  "Elizabeth has already attached a gun to your left hand (Use left click). \n\n",
        				  "You can pick up other skills by using your right hand (Use right click).\n\n", 
        				  "You can move around using WASD or the Arrow keys and use the Space bar to jump.\n\n",
        				  "Alright Patrick. Time to begin your revenge. "};
        t = gameObject.GetComponent<Text>(); 
        t.text = story[i]+story[i+1]+story[i+2]+story[i+3];
        i = 1; 
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextDialogue(){
    	if(i < story.Length-3){
        	t.text = story[i]+story[i+1]+story[i+2]+story[i+3];
        }
        if(i >= 29){
        	SceneManager.LoadScene(1);
        }
        i++;
    }

}
