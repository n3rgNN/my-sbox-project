using Sandbox;

namespace MyProject;

/// <summary>
/// Door structure with open/close functionality.
/// </summary>
public partial class Door : Structure
{
	[Net] public bool IsOpen { get; set; } = false;
	private Vector3 _closedPosition;
	private Vector3 _openPosition;

	public override void Spawn()
	{
		base.Spawn();
		SetModel( "models/door/door.vmdl" );
		_closedPosition = Position;
		_openPosition = Position + Vector3.Up * 100f;
	}

	/// <summary>
	/// Toggle door open/closed
	/// </summary>
	public void Toggle()
	{
		IsOpen = !IsOpen;
		UpdatePosition();
		Log.Info( $"Door is now {(IsOpen ? "OPEN" : "CLOSED")}" );
	}

	/// <summary>
	/// Open the door
	/// </summary>
	public void Open()
	{
		IsOpen = true;
		UpdatePosition();
		Log.Info( "Door opened!" );
	}

	/// <summary>
	/// Close the door
	/// </summary>
	public void Close()
	{
		IsOpen = false;
		UpdatePosition();
		Log.Info( "Door closed!" );
	}

	private void UpdatePosition()
	{
		Position = IsOpen ? _openPosition : _closedPosition;
	}
}
