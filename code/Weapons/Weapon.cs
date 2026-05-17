using Sandbox;

namespace MyProject;

/// <summary>
/// Base weapon class for all weapons in the game.
/// </summary>
public partial class Weapon : Entity
{
	[Net] public int Ammo { get; set; }
	[Net] public int MaxAmmo { get; set; } = 30;
	[Net] public float FireRate { get; set; } = 0.1f;
	[Net] public float Damage { get; set; } = 10f;

	private float _lastFireTime = 0f;

	public override void Spawn()
	{
		base.Spawn();
		Ammo = MaxAmmo;
		IsNetworkingEnabled = true;
	}

	/// <summary>
	/// Fire the weapon
	/// </summary>
	public virtual void Fire()
	{
		if ( Ammo <= 0 )
		{
			Log.Warning( "Out of ammo!" );
			return;
		}

		if ( Realtime.Now < _lastFireTime + FireRate )
		{
			return;
		}

		_lastFireTime = Realtime.Now;
		Ammo--;

		Log.Info( $"Weapon fired! Ammo: {Ammo}/{MaxAmmo}" );
	}

	/// <summary>
	/// Reload the weapon
	/// </summary>
	public virtual void Reload()
	{
		Ammo = MaxAmmo;
		Log.Info( "Weapon reloaded!" );
	}
}
