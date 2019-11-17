using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour 
{

	private void Awake ()
	{
		Debugger.LaunchAssert(_followAt != null, "Falta asignar la referencia _followAt", this.gameObject);
		
		_camera = this.GetComponent<Camera>();
	}
	
	private void Update ()
	{
		_minX = Screen.width * _percentMinX;
		_maxX = Screen.width * _percentMaxX;
		_minY = Screen.height * _percentMinY;
		_maxY = Screen.height * _percentMaxY;

		float moveX = 0f, moveY = 0f;
		_currentScreenPosition = _camera.WorldToScreenPoint(_followAt.position);
		if(_currentScreenPosition.x > _maxX)
		{
			moveX = _followAt.position.x - _camera.ScreenToWorldPoint(new Vector3(_maxX, 0f, 0f)).x;
		}
		else if(_currentScreenPosition.x < _minX)
		{
			moveX = _followAt.position.x - _camera.ScreenToWorldPoint(new Vector3(_minX, 0f, 0f)).x;
		}

		if(_currentScreenPosition.y > _maxY)
		{
			moveY = _followAt.position.y - _camera.ScreenToWorldPoint(new Vector3(0f, _maxY, 0f)).y;
		}
		else if(_currentScreenPosition.y < _minY)
		{
			moveY = _followAt.position.y - _camera.ScreenToWorldPoint(new Vector3(0f, _minY, 0f)).y;
		}

		_camera.transform.Translate(moveX, moveY, 0f, Space.World);
	}

	[Header("GameObject a seguir")]
	[SerializeField]
	private Transform _followAt = null;

	[Header("Rangos de pantalla")]
	[SerializeField][Range(0.05f, 0.45f)]
	private float _percentMinX = 0.3f;
	[SerializeField][Range(0.55f, 0.95f)]
	private float _percentMaxX = 0.7f;
	[SerializeField][Range(0.05f, 0.45f)]
	private float _percentMinY = 0.3f;
	[SerializeField][Range(0.55f, 0.95f)]
	private float _percentMaxY = 0.7f;

	private Camera _camera;

	private Vector3 _currentScreenPosition;

	private float _minX, _maxX, _minY, _maxY;
}
