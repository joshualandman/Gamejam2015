using UnityEngine;
using System.Collections;

public class AI {
	
	public enum State
	{
		WAITING,
		SEEKING,
		ATTACKING,
		RETURNING
	}
	
	public GameObject player;
	
	
	/// <summary>
	/// Checks if the target is within Constants.AWARENESS_RADIUS
	/// of obj
	/// 
	/// returns true if the player is within, false if not
	/// </summary>
	public static bool InRange(Vector3 objPos, Vector3 targetPos, float radius)
	{
		
		Vector3 dist = objPos - targetPos;
		if (dist.magnitude < radius) 
		{
			return true;
		}
		return false;
	}
	
	/// <summary>
	/// obj Seeks the specified target, target at speed.
	/// </summary>
	/// <param name="obj">Object to move.</param>
	/// <param name="target">Target to seek.</param>
	/// <param name="speed">Speed to move at.</param>
	public static Vector3 Seek(Vector3 objPos, Vector3 targetPos, float speed)
	{
		Vector3 desired = targetPos - objPos;
		desired.Normalize ();
		Vector3 scaleVec = new Vector3(speed, 0.0f, speed);
		desired.Scale (scaleVec);
		
		//If using acceleration / velocity
		//desired -= obj.currentVelocity
		
		//Zero Y axiscause fake 2d
		desired.y = 0;
		//desired = new Vector3 (desired.x, 0, desired.y);
		
		return desired;
	}
	
	/// <summary>
	/// Obj seeks the specified target, Returns true if within radius
	/// </summary>
	/// <param name="obj">Object.</param>
	/// <param name="target">Target.</param>
	/// <param name="radius">Radius.</param>
	/// <param name="speed">Speed.</param>
	public static bool Arrive(Vector3 objPos, Vector3 targetPos, float speed, float radius)
	{
		Vector3 desired = Seek (objPos, targetPos, speed);
		
		if ((objPos - targetPos).magnitude > MyConstants.ARRIVE_RADIUS) 
		{
			return true;
		}
		return false;
	}
	
	/// <summary>
	/// Obj Flees the specified target, at speed.
	/// </summary>
	/// <param name="obj">Object to run.</param>
	/// <param name="target">Target to run from.</param>
	/// <param name="speed">Speed to run at.</param>
	public static Vector3 Flee(Vector3 objPos, Vector3 targetPos, float speed)
	{
		Vector3 desired = Seek (objPos, targetPos, speed);
		Vector3 scaleVec = new Vector3 (-1, 0, -1);
		desired.Scale (scaleVec);
		return desired;
	}
}
