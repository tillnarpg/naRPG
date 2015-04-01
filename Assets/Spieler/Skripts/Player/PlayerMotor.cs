using UnityEngine;
using System.Collections;

using Helper;



public class PlayerMotor : MonoBehaviour {

	#region Public Fields & Properties

	public float walkSpeed = 3f;
	public float runSpeed = 5f;
	public float sprintSpeed = 7f;
	public float _rotationSpeed = 140f;
	public float jumpHeight = 10f;
	public float gravity = 20f;

	#endregion

	#region Private Fields & Properties

	private float _horizontal = 0f;
	private float _vertical = 0f;

	private float _moveSpeed;

	private float _airVelocity = 0f;

	private Transform _myXform;

	private Vector3 _moveDirection = Vector3.zero;

	private CharacterController _controller;

	private Animator _animator;

	private SpeedState _speedState = SpeedState.Run;
	private CameraState _cameraState;

	private PlayerCharacter _pc;
	private PlayerCamera _camera;

	#endregion

	#region Getters & Setters

	/// <summary>
	/// Gets or sets the move speed.
	/// </summary>
	/// <value>The move speed.</value>
	public float MoveSpeed
	{
		get{return _moveSpeed;}
		set{_moveSpeed = value;}
	}

	#endregion

	#region System Methods

	// Use this for initialization
	void Start () 
	{
		if (networkView.isMine || Network.peerType == NetworkPeerType.Disconnected)
		{
			// Cache references to child components of this gameObject
			_myXform = this.GetComponent<Transform>();

			_pc = this.GetComponent<PlayerCharacter>();
			_camera = this.GetComponent<PlayerCamera>();

			_animator = _pc.Animator;
			_controller = _pc.Controller;

			_animator.SetBool(AnimatorConditions.Grounded, true);
		}
		else
		{
			enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		_cameraState = _camera.CameraState;

		CalculateSpeed();
		
		_animator.SetFloat(AnimatorConditions.AirVelocity, _airVelocity);

		switch (_cameraState)
		{
			case CameraState.Normal:

			//Allow the player to rotate their character
			if (Input.GetAxis (PlayerInput.MouseX) > 0.1f || Input.GetAxis (PlayerInput.MouseX) < -0.1f)
			{
				_myXform.Rotate(0f, Input.GetAxis (PlayerInput.MouseX) * _rotationSpeed * Time.deltaTime, 0f);
			}

			if (_controller.isGrounded == true)
			{
				_moveDirection = Vector3.zero;
				_airVelocity = 0f;

				_animator.SetBool(AnimatorConditions.Grounded, true);

				//Cache the values returned by human input into float variables
				_horizontal = Input.GetAxis (PlayerInput.Horizontal);
				_vertical = Input.GetAxis(PlayerInput.Vertical);

				//Set the cached input values as the conditions for the animator FSM
				_animator.SetFloat (AnimatorConditions.Direction,_horizontal);
				_animator.SetFloat (AnimatorConditions.Speed, _vertical);

				if (Input.GetButtonDown(PlayerInput.Jump))
				{
					Jump();
				}

			}
			else
			{
				_moveDirection.x = Input.GetAxis (PlayerInput.Horizontal) * _moveSpeed;
				_moveDirection.z = Input.GetAxis (PlayerInput.Vertical) * _moveSpeed;
				_moveDirection = _myXform.TransformDirection (_moveDirection);

				_animator.SetBool (AnimatorConditions.Grounded, false);
			}

			break;

			case CameraState.Target:



			break;
		}

		//Apply simulsted Gravity to the Character
		_moveDirection.y -= gravity * Time.deltaTime;

		//Move the Character with the _moveDirection Vector3 calculated above
		_controller.Move(_moveDirection * Time.deltaTime);

	}

	#endregion

	#region Custom Methods

	private void CalculateSpeed()
	{
		switch (_speedState)
		{
			case SpeedState.Walk:

				_moveSpeed = walkSpeed;

				break;

			case SpeedState.Run:

				_moveSpeed= runSpeed;

				break;

			case SpeedState.Sprint:

				_moveSpeed = sprintSpeed;

				break;
		}
	}

	private void Jump()
	{
		_moveDirection.y = jumpHeight;
		_airVelocity -= Time.time;
	}

	#endregion

}
