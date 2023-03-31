using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Weapon : GameEntity
{
	public Weapon(int level, int damage, int speed, int critChance, WeaponQuality quality)
	{

	}
	public abstract WeaponDamageType DamageType { get; }
	public abstract int Level { get; }
	public abstract WeaponQuality WeaponQuality { get; }


	public abstract int Damage { get; }
	public abstract int Speed { get; }
	public abstract int CritChance { get; }
	public abstract int Durability { get; }
}

public class Sword: Weapon
{
	public Sword(int level, int damage, int speed, int critChance, WeaponQuality quality) : base(level, damage, speed, critChance, quality)
	{
		this.level = level;
		this.speed = speed;
		this.critChance = critChance;
		this.damage = damage;
		this.quality = quality;
	}


	private WeaponDamageType damageType = WeaponDamageType.Cut;
	public override WeaponDamageType DamageType => damageType;

	private int level;
	public override int Level => level;

	private WeaponQuality quality;
	public override WeaponQuality WeaponQuality => quality;


	private int damage;
	public override int Damage => damage;


	private int speed;
	public override int Speed => speed;


	private int critChance;
	public override int CritChance => critChance;


	private int durability;
	public override int Durability => durability;
}

public class Spear : Weapon
{
	public Spear(int level, int damage, int speed, int critChance, WeaponQuality quality) : base(level, damage, speed, critChance, quality)
	{
		this.level = level;
		this.speed = speed;
		this.critChance = critChance;
		this.damage = damage;
		this.quality = quality;
	}

	private WeaponDamageType damageType = WeaponDamageType.Pierce;
	public override WeaponDamageType DamageType => damageType;

	private int level;
	public override int Level => level;

	private WeaponQuality quality;
	public override WeaponQuality WeaponQuality => quality;

	private int damage;
	public override int Damage => damage;


	private int speed;
	public override int Speed => speed;


	private int critChance;
	public override int CritChance => critChance;


	private int durability;
	public override int Durability => durability;
}

public class Axe : Weapon
{
	public Axe(int level, int damage, int speed, int critChance, WeaponQuality quality) : base(level, damage, speed, critChance, quality)
	{
		this.level = level;
		this.speed = speed;
		this.critChance = critChance;
		this.damage = damage;
		this.quality = quality;
	}

	private WeaponDamageType damageType = WeaponDamageType.Cut;
	public override WeaponDamageType DamageType => damageType;

	private int level;
	public override int Level => level;

	private WeaponQuality quality;
	public override WeaponQuality WeaponQuality => quality;

	private int damage;
	public override int Damage => damage;


	private int speed;
	public override int Speed => speed;


	private int critChance;
	public override int CritChance => critChance;


	private int durability;
	public override int Durability => durability;
}

public class Maze : Weapon
{
	public Maze(int level, int damage, int speed, int critChance, WeaponQuality quality) : base(level, damage, speed, critChance, quality)
	{
		this.level = level;
		this.speed = speed;
		this.critChance = critChance;
		this.damage = damage;
		this.quality = quality;
	}

	private WeaponDamageType damageType = WeaponDamageType.Blunt;
	public override WeaponDamageType DamageType => damageType;

	private int level;
	public override int Level => level;

	private WeaponQuality quality;
	public override WeaponQuality WeaponQuality => quality;

	private int damage;
	public override int Damage => damage;


	private int speed;
	public override int Speed => speed;


	private int critChance;
	public override int CritChance => critChance;


	private int durability;
	public override int Durability => durability;
}

public class Staff : Weapon
{
	public Staff(int level, int damage, int speed, int critChance, WeaponQuality quality) : base(level, damage, speed, critChance, quality)
	{
		this.level = level;
		this.speed = speed;
		this.critChance = critChance;
		this.damage = damage;
		this.quality = quality;
	}

	private WeaponDamageType damageType = WeaponDamageType.Blunt;
	public override WeaponDamageType DamageType => damageType;

	private int level;
	public override int Level => level;

	private WeaponQuality quality;
	public override WeaponQuality WeaponQuality => quality;

	private int damage;
	public override int Damage => damage;


	private int speed;
	public override int Speed => speed;


	private int critChance;
	public override int CritChance => critChance;


	private int durability;
	public override int Durability => durability;
}

public class Dagger : Weapon
{
	public Dagger(int level, int damage, int speed, int critChance, WeaponQuality quality) : base(level, damage, speed, critChance, quality)
	{
		this.level = level;
		this.speed = speed;
		this.critChance = critChance;
		this.damage = damage;
		this.quality = quality;
	}

	private WeaponDamageType damageType = WeaponDamageType.Cut;
	public override WeaponDamageType DamageType => damageType;

	private int level;
	public override int Level => level;

	private WeaponQuality quality;
	public override WeaponQuality WeaponQuality => quality;

	private int damage;
	public override int Damage => damage;


	private int speed;
	public override int Speed => speed;


	private int critChance;
	public override int CritChance => critChance;


	private int durability;
	public override int Durability => durability;
}

public class Bow : Weapon
{
	public Bow(int level, int damage, int speed, int critChance, WeaponQuality quality) : base(level, damage, speed, critChance, quality)
	{
		this.level = level;
		this.speed = speed;
		this.critChance = critChance;
		this.damage = damage;
		this.quality = quality;
	}

	private WeaponDamageType damageType = WeaponDamageType.Pierce;
	public override WeaponDamageType DamageType => damageType;

	private int level;
	public override int Level => level;

	private WeaponQuality quality;
	public override WeaponQuality WeaponQuality => quality;

	private int damage;
	public override int Damage => damage;


	private int speed;
	public override int Speed => speed;


	private int critChance;
	public override int CritChance => critChance;


	private int durability;
	public override int Durability => durability;
}