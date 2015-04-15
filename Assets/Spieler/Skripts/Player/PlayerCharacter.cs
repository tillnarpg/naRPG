using UnityEngine;
using System.Collections;

using Helper;

[RequireComponent(typeof(NetworkView))]
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]

[RequireComponent(typeof(PlayerCamera))]
[RequireComponent(typeof(PlayerMotor))]

[AddComponentMenu("APP/PlayerCharacter")]

public class PlayerCharacter : MonoBehaviour 
{
	#region Public Fields & Properties
	
	
	
	#endregion
	
	#region Private Fields & Properties
	
	private CharacterController _controller;
	
	private Animator _animator;
	private RuntimeAnimatorController _animatorController;
	
	#endregion
	
	#region Getters & Setters
	
	public Animator Animator 
	{
		get{ return this._animator;}
	}
	
	public CharacterController Controller
	{
		get{ return this._controller;}
	}
	
	#endregion
	
	#region System Methods
	
	private void Awake()
	{
		_animator = this.GetComponent<Animator> ();
		_controller = this.GetComponent<CharacterController> ();
	}
	
	// Use this for initialization
	private void Start () 
	{
		if(GetComponent<NetworkView>()!=null)
		{
			if (GetComponent<NetworkView>().isMine || Network.peerType == NetworkPeerType.Disconnected)
			{
				_animatorController = Resources.Load (Resource.AnimatorController) as RuntimeAnimatorController;
				_animator.runtimeAnimatorController = _animatorController;
				
				_controller.center = new Vector3(0f,1f,0f);
				_controller.height = 1.8f;
			}
			else
			{
				enabled = false;
			}
		}
		else
		{
			Debug.Log ("Somehow you have managed to start the game without a NetworkView Component");
		}
	}
	
	
	#endregion 
}
