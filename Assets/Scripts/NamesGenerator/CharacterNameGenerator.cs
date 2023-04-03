using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterNameGenerator
{
	private GoblinNameGenerator goblinName = new GoblinNameGenerator();
	private DwarfNameGenerator dwarfName = new DwarfNameGenerator();
	private ChameleoniteNameGenerator chameleoniteName = new ChameleoniteNameGenerator();
	private MudbornNameGenerator mudbornName = new MudbornNameGenerator();
	private TrollNameGenerator trollName = new TrollNameGenerator();
	private GolemNameGenerator golemName = new GolemNameGenerator();

	public string GetCharacterName(CharacterRace race)
	{
		string name = "";

		switch (race)
		{
			case CharacterRace.Goblin:
				name = goblinName.GetGoblinName();
				break;
			case CharacterRace.Dwarf:
				name = dwarfName.GetDwarfName();
				break;
			case CharacterRace.Chameleonites:
				name = chameleoniteName.GetChameleoniteName();
				break;
			case CharacterRace.Mudborn:
				name = mudbornName.GetMudbornName();
				break;
			case CharacterRace.Troll:
				name = trollName.GetTrollName();
				break;
			case CharacterRace.Golem:
				name = golemName.GetGolemName();
				break;
		}

		return name.ToUpper();
	}



	private class GoblinNameGenerator
	{
		private string[] sillables = new string[] {"guz", "klin", "ohg", "pritz", "snik", "gob", "skit", "Chilzk", "spat", "krab",
		"waz", "quib", "zik", "zity", "zit", "kradt", "guk", "yik", "flibz", "mok", "Waa", "Tiz", "tulk", "flib",
		"mohz", "tolz", "khaz", "xald", "duz", "mokx", "hagha", "friz", "frooz", "fklix", "todz", "tuxd"};

		public string GetGoblinName()
		{
			string name = "";
			int temp = Random.Range(1, 5);

			for(int i= 0; i < temp; i++)
			{
				name += sillables[Random.Range(0, sillables.Length)];
			}

			return name.ToUpper();
		}
	}
	private class DwarfNameGenerator
	{
		private string[] sillables = new string[] {"Dur", "kon", "drog", "brik", "thon", "thrak", "Thrim", "hrok", "druk", "Fin", "Din",
		"grom", "krag", "nor", "fim", "thran", "grun", "gon", "kot", "kul", "darim", "tokt", "bron", "bor", "skat", "kyr", "thrum",
		"barl", "morl", "nal", "jorl", "thrak"};

		public string GetDwarfName()
		{
			string name = "";
			float temp = Random.value;

			if(temp < 0.4)
			{
				name += sillables[Random.Range(0, sillables.Length)];
			}
			else
			{
				name += sillables[Random.Range(0, sillables.Length)] + sillables[Random.Range(0, sillables.Length)];
			}
						

			return name.ToUpper();
		}
	}
	private class ChameleoniteNameGenerator
	{
		private string[] sillables = new string[] {"Liizk", "uhruu", "kaahzaa", "laazk", "hoovu", 
			"kiilt", "thu zko", "alht", "voo lhou",
		"haalt", "yuuot", "To pek zhu", "lou zou", "chapek", "tolk'tu", "caaz'luu'tzik", "nax", "ven", "fe",
		"sa", "serz", "nax"};

		public string GetChameleoniteName()
		{
			string name = "";
			int temp = Random.Range(1, 3);

			switch (temp)
			{
				case 0:
					name = sillables[Random.Range(0, sillables.Length)];
					break;
				case 1:
					name = sillables[Random.Range(0, sillables.Length)] + " " + sillables[Random.Range(0, sillables.Length)];
					break;
				case 2:
					name = sillables[Random.Range(0, sillables.Length)] + "'" + sillables[Random.Range(0, sillables.Length)];
					break;
			}

			return name.ToUpper();
		}
	}
	private class MudbornNameGenerator
	{
		private string[] sillables = new string[] {"Ku", "cho", "kla", "pulu", "gloop", "gloo", "bloo", "luu", "lou",
		"Bau", "Wail", "luou", "Ouul", "Buu", "Vaou", "Lhuo", "Anhuu", "Chuo", "Ohl", "Wuuo", "Ou", "Eluu", "Olbe", "Eneo",
		"Fruulg", "Elun"};

		private string[] sillableEnd = new string[] {"t", "ru", "k", "z", "bu", "b", "y", "q", "r", "y", "u", "p", "c", "ut", "de",
		"ol", "h", "uh", "eon"};

		private string[] secondNameSillable = new string[] { "ou", "ean", "bo", "uem", "unn", "od", "uen", "oul", "enn", "ul", "oem",
		"huu", "gloo", "gloop", "cho", "elu", "unee", "weh", "uon", "abzuu"};


		public string GetMudbornName()
		{
			string name = "";

			float temp = Random.value;

			if(temp < 0.4f)
			{
				name = sillables[Random.Range(0, sillables.Length)];
				name += sillableEnd[Random.Range(0, sillableEnd.Length)];
				name += " " + secondNameSillable[Random.Range(0, secondNameSillable.Length)];
				name += sillableEnd[Random.Range(0, sillableEnd.Length)];
			}
			else if(temp < 0.6f)
			{
				name = sillables[Random.Range(0, sillables.Length)];
				name += secondNameSillable[Random.Range(0, secondNameSillable.Length)];
			}
			else if(temp < 1f)
			{
				name = secondNameSillable[Random.Range(0, secondNameSillable.Length)];
				name += sillableEnd[Random.Range(0, sillableEnd.Length)];
				name += " " + sillables[Random.Range(0, sillables.Length)];
			}

			return name.ToUpper();
		}
	}
	private class TrollNameGenerator
	{
		private string[] sillables = new string[] {"Kouhu", "Haanhe", "Ouunhe", "Anhee", "Dreem", "Deeneh", "Uueh", "Aheene", 
		"Anhuu", "Ounhzu", "Koonhu", "Aenha", "ulvhoo", "Anhiem", "Heaale", "Duln", "Hoourlu", "Aeene", "Eoniee", "iaamlu",
		"Hooznu"};

		private string[] shortSillables = new string[] {"Uhn", "ame", "Anie", "Os", "Yl", "eym", "iya", "iud", "ael", "ouh",
		"an", "het", "yoh", "iem", "eri", "ys", "onh"};

		private string[] longSillables = new string[] {"Ayeel", "Uhlunme", "Oohnlu", "Iafnehe", "Keaynhu", "Omawuu", "nheenme",
		"Zoolunhee", "syheeah", "bneelok", "nheezlu", "Ythee", "adulhee", "Isheenlu", "ohuudnre"};


		public string GetTrollName()
		{
			string name = "";

			int temp = Random.Range(0, 6);

			switch (temp)
			{
				case 0:
					name = sillables[Random.Range(0, sillables.Length)];
					name += shortSillables[Random.Range(0, shortSillables.Length)];
					break;
				case 1:
					name = sillables[Random.Range(0, sillables.Length)];
					name += " " + longSillables[Random.Range(0, longSillables.Length)];
					break;
				case 2:
					name = longSillables[Random.Range(0, longSillables.Length)];
					name += " " + sillables[Random.Range(0, sillables.Length)];
					break;
				case 3:
					name = shortSillables[Random.Range(0, shortSillables.Length)];
					name += longSillables[Random.Range(0, longSillables.Length)];
					name += " " + sillables[Random.Range(0, sillables.Length)];
					break;
				case 4:
					name = sillables[Random.Range(0, sillables.Length)];
					name += " " + shortSillables[Random.Range(0, shortSillables.Length)];
					break;
				case 5:
					name = shortSillables[Random.Range(0, shortSillables.Length)];
					name += sillables[Random.Range(0, sillables.Length)];
					name += " " + longSillables[Random.Range(0, longSillables.Length)];
					break;
			}

			return name.ToUpper();
		}
	}
	private class GolemNameGenerator
	{
		private string[] sillables = new string[] {"to", "ku", "Ru", "Tro", "pu", "tek", "pok", "tu", "cruk", "stru", 
		"nek", "tak", "trot", "Jek", "jrok", "guk", "jot"};

		private string[] sillables_2 = new string[] {"tu", "rru", "kaz", "kat", "truk", "jurk", "tohn", "uk", "tro", "uklu", "thor",
		"thur", "imr", "tum", "tep", "kon", "zrop"};
		private string[] sillables_3 = new string[] {"ko", "to", "karek", "lunt", "ozt", "ruhn", "taruk", "olku", "tropek", "kogj",
		"oprut", "ktre", "atukna", "prokna", "zrot"};

		public string GetGolemName()
		{
			string name = "";

			int temp = Random.Range(0, 7);

			switch (temp)
			{
				case 0:
					name = sillables[Random.Range(0, sillables.Length)] + sillables_2[Random.Range(0, sillables_2.Length)];
					break;
				case 1:
					name = sillables_2[Random.Range(0, sillables_2.Length)] + sillables[Random.Range(0, sillables.Length)];
					break;
				case 2:
					name = sillables_2[Random.Range(0, sillables_2.Length)] + " " +
						sillables[Random.Range(0, sillables.Length)] + sillables_3[Random.Range(0, sillables_3.Length)];
					break;
				case 3:
					name = sillables[Random.Range(0, sillables.Length)] +
						sillables_3[Random.Range(0, sillables_3.Length)] + " " +
						sillables_2[Random.Range(0, sillables_2.Length)] + sillables[Random.Range(0, sillables.Length)];
					break;
				case 4:
					name = sillables_3[Random.Range(0, sillables_3.Length)] + " " + sillables[Random.Range(0, sillables.Length)];
					break;
				case 5:
					name = sillables[Random.Range(0, sillables.Length)] + sillables_3[Random.Range(0, sillables_3.Length)];
					break;
				case 6:
					name = sillables_3[Random.Range(0, sillables_3.Length)] + sillables_2[Random.Range(0, sillables_2.Length)];
					break;
			}

			
			return name.ToUpper();
		}
	}
}
