using UnityEngine;
using System.Collections;

using Helper;

public class PlayerCamera : MonoBehaviour {
	
	#region Private Fields & Properties
	
	//Used to position the camera
	private Vector3 _cameraaNormalPosition = new Vector3(-0.1087829f,1.443486f,-6.936074f);
	
	//Used to rotate the camera
	[SerializeField]
	private float sensitivity = 5f;
	[SerializeField]
	public float minimumAngle = -40f;
	[SerializeField]
	public float maximumAngle = 60f;
	
	private float rotationY = 0f;
	
	private Transform _player;
	private Transform _camera;
	
	private PlayerCharacter _pc;
	
	private CameraState _state = CameraState.Normal;
	
	private CameraTargetObject _cameraTargetObject;
	private CameraMountPoint _cameraMountPoint;
	
	#endregion
	
	#region Getters & Setters
	
	public CameraState CameraState
	{
		get{return _state;}
	}
	
	#endregion
	
	#region System Methods
	
	// Use this for initialization
	void Start () 
	{
		if (networkView.isMine || Network.peerType == NetworkPeerType.Disconnected)
		{
			_pc = this.GetComponent<PlayerCharacter>();
			
			_camera = GameObject.FindGameObjectWithTag (GameTag.PlayerCamera).transform;
			_player = this.transform;
			
			//Create an empty object at runtime for the camera to look at
			_cameraTargetObject = new CameraTargetObject();
			_cameraTargetObject.Init (
				"Camera Target",
				new Vector3(0f,1f,0f),
				new GameObject().transform,
				_player.transform
				);
			
			//Create an empty object at runtime for the camera to sit on
			_cameraMountPoint = new CameraMountPoint();
			_cameraMountPoint.Init (
				"Camera Mount",
				_cameraaNormalPosition,
				new GameObject().transform,
				_cameraTargetObject.XForm
				);
			_camera.parent = _cameraTargetObject.XForm.parent;
		}
		else
		{
			enabled = false;
		}
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		//FSM used to govern how the camera is supposed to behave
		switch(_state)
		{
			case CameraState.Normal:
			
				RotateCamera();
				_camera.position = _cameraMountPoint.XForm.position;
				_camera.LookAt(_cameraTargetObject.XForm);
			
				break;
			
			case CameraState.Target:
			
			
			
				break;
		}
	}
	
	#endregion
	
	#region Custom Methods
	
	private void RotateCamera()
	{
		rotationY -= Input.GetAxis(PlayerInput.MouseY)* sensitivity;
		rotationY = Mathf.Clamp(rotationY,minimumAngle,maximumAngle);
		
		_cameraTargetObject.XForm.localEulerAngles = new Vector3(-rotationY,_cameraTargetObject.XForm.localEulerAngles.y,0);
	}
	
	#endregion
}
