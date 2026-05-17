using Sandbox;

namespace MyProject;

/// <summary>
/// Base player controller for multiplayer gameplay.
/// </summary>
public partial class Player : Entity
{
	private Vector3 _eyePosition;
	private Rotation _eyeRotation;
	private float _walkSpeed = 200f;
	private float _sprintSpeed = 350f;

	public override void Spawn()
	{
		base.Spawn();
		SetModel( "models/citizen/citizen.vmdl" );
		SetupPhysicsFromModel( PhysicsMotionType.Dynamic );
		EnableAllCollisions = true;
		IsNetworkingEnabled = true;
	}

	[Event.Frame]
	public void FrameSimulate()
	{
		if ( !IsLocalPawn ) return;

		// Handle input
		HandleInput();
		HandleMovement();
		HandleCamera();
	}

	private void HandleInput()
	{
		// Input handling will be added here
	}

	private void HandleMovement()
	{
		// Movement logic will be added here
	}

	private void HandleCamera()
	{
		_eyePosition = Position + Vector3.Up * 64f;
		_eyeRotation = Rotation.Identity;
	}

	public override void TakeDamage( DamageInfo info )
	{
		base.TakeDamage( info );
		Log.Info( $"Player took {info.Damage} damage!" );
	}
}
