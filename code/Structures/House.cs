using Sandbox;

namespace MyProject;

/// <summary>
/// House structure with multiple doors.
/// </summary>
public partial class House : Structure
{
	[Net] public List<Door> Doors { get; set; } = new();

	public override void Spawn()
	{
		base.Spawn();
		SetModel( "models/house/house.vmdl" );
		MaxHealth = 500f;
		Health = MaxHealth;

		// Create 2 doors for the house
		CreateDoors( 2 );
	}

	/// <summary>
	/// Create specified number of doors for the house
	/// </summary>
	private void CreateDoors( int doorCount )
	{
		for ( int i = 0; i < doorCount; i++ )
		{
			var door = new Door();
			door.Position = Position + Vector3.Right * (i * 150f);
			door.Spawn();
			Doors.Add( door );
			Log.Info( $"Door {i + 1} created at position {door.Position}" );
		}
	}

	/// <summary>
	/// Get door by index
	/// </summary>
	public Door GetDoor( int index )
	{
		if ( index >= 0 && index < Doors.Count )
		{
			return Doors[index];
		}
		Log.Warning( $"Door index {index} out of range!" );
		return null;
	}

	/// <summary>
	/// Open all doors
	/// </summary>
	public void OpenAllDoors()
	{
		foreach ( var door in Doors )
		{
			door.Open();
		}
		Log.Info( "All doors opened!" );
	}

	/// <summary>
	/// Close all doors
	/// </summary>
	public void CloseAllDoors()
	{
		foreach ( var door in Doors )
		{
			door.Close();
		}
		Log.Info( "All doors closed!" );
	}

	/// <summary>
	/// Toggle all doors
	/// </summary>
	public void ToggleAllDoors()
	{
		foreach ( var door in Doors )
		{
			door.Toggle();
		}
		Log.Info( "All doors toggled!" );
	}

	protected override void OnDestroyed()
	{
		// Destroy all doors when house is destroyed
		foreach ( var door in Doors )
		{
			door.Delete();
		}
		base.OnDestroyed();
	}
}
