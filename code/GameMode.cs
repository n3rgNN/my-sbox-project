using Sandbox;

namespace MyProject;

/// <summary>
/// Main game mode for the multiplayer game.
/// </summary>
public partial class GameMode : Sandbox.GameManager
{
	public static GameMode Current { get; set; }

	public GameMode()
	{
		Current = this;
	}

	public override void PostLevelLoaded()
	{
		base.PostLevelLoaded();
		Log.Info( "Game mode initialized!" );
	}

	[Event.Frame]
	protected virtual void FrameSimulate()
	{
		// Game logic updates
	}
}
