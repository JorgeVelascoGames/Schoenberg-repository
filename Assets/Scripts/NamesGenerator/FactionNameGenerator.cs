using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionNameGenerator
{
	private string[] firstPlaceNoun = new string[] { "Warriors", "Hunters", "Chosen ones", "Knights", 
		"Beastmasters", "Gladiators", "Shadows", "Templars", "Mystics", "Alchemists", "Rangers", "Assassins", "Paladins", "Dragonriders" };
	private string[] secondPlaceNoun = new string[] { "souls", "wyvernscale", "the dark sun", "the endless cave", 
		"the distant stars", "the pit", "the distant death", "the sunless fate"};

	private string[] firstPlaceverb = new string[] {"enchanted", "vanquised", "incinerated", "conjured", "cursed", "Banished", "expelled", 
	"betrayed", "forsaken", "eviscerated", "purged", "exiled", "decimated"};

	private string[] secondPlaceAdj = new string[] {"Valiant", "Courageous", "Mighty", "Heroic", "Fierce", "Savage", "Ferocious", "Cursed", "Dark", 
	"Radiant", "Ethereal", "Divine", "Ancient", "Dreadful", "Haunted", "Malevolent", "Sinister", "Shadowy", "Twisted", "Wicked", "Blessed", "Holy",
	"Magical", "Mythical", "Enigmatic", "Majestic", "Legendary"};



	public string GetFactionName()
	{
		string name = MethodFour();

		int temp = Random.Range(0, 4);


		switch (temp)
		{
			case 0:
				name = MethodOne();
				break;
			case 1:
				name = MethodTwo();
				break;
			case 2:
				name = MethodThree();
				break;
			case 3:
				name = MethodFour();
				break;
		}

		return name.ToUpper();
	}

	private string MethodOne()
	{
		string name = "";

		string firstPart = firstPlaceNoun[Random.Range(0, firstPlaceNoun.Length)];
		string secondPart = secondPlaceNoun[Random.Range(0, secondPlaceNoun.Length)];

		name = firstPart + " of " + secondPart;
				
		return name;
	}

	private string MethodTwo()
	{
		string name = "";

		string firstPart = secondPlaceAdj[Random.Range(0, secondPlaceAdj.Length)];
		string secondPart = firstPlaceNoun[Random.Range(0, firstPlaceNoun.Length)];

		name = firstPart + " " + secondPart;

		return name;
	}

	private string MethodThree()
	{
		string name = "";

		string firstPart = firstPlaceverb[Random.Range(0, firstPlaceverb.Length)];
		string secondPart = firstPlaceNoun[Random.Range(0, firstPlaceNoun.Length)];

		name = firstPart + " " + secondPart;

		return name;
	}

	private string MethodFour()
	{
		string name = "";

		string firstPart = firstPlaceverb[Random.Range(0, firstPlaceverb.Length)];
		string secondPart = MethodOne();

		name = firstPart + " " + secondPart;

		return name;
	}
}
