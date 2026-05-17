using Sandbox;

namespace MyProject;

/// <summary>
/// Base structure class for buildings and interactive objects.
/// </summary>
public partial class Structure : Entity
{
	[Net] public float Health { get; set; } = 100f;
	[Net] public float MaxHealth { get; set; } = 100f;

	public override void Spawn()
	{
		base.Spawn();
		SetupPhysicsFromModel( PhysicsMotionType.Static );
		IsNetworkingEnabled = true;
	}

	/// <summary>
	/// Deal damage to the structure
	/// </summary>
	public virtual void TakeDamage( float damage )
	{
		Health -= damage;
		Log.Info( $"Structure took {damage} damage! Health: {Health}/{MaxHealth}" );

		if ( Health <= 0 )
		{
			OnDestroyed();
		}
	}

	/// <summary>
	/// Called when structure is destroyed
	/// </summary>
	protected virtual void OnDestroyed()
	{
		Log.Info( "Structure destroyed!" );
		Delete();
	}
}
