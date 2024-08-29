using UnityEngine;

namespace PROMETEO___Car_Controller.Scripts
{
	public class CameraFollow : MonoBehaviour {
	
		public static CameraFollow Instance { get; private set; }
	
		public GameObject car;
		[Range(1, 10)]
		public float followSpeed = 2;
		[Range(1, 10)]
		public float lookSpeed = 5;
		Vector3 initialCameraPosition;
		Vector3 initialCarPosition;
		Vector3 absoluteInitCameraPosition;

		void Start(){
			Instance = this;
			initialCameraPosition = gameObject.transform.position;
			if (car)
				initialCarPosition = car.transform.position;
			absoluteInitCameraPosition = initialCameraPosition - initialCarPosition;
		}
	
		public void SetCar(GameObject _car)
		{
			car = _car;
			initialCarPosition = car.transform.position;
			absoluteInitCameraPosition = initialCameraPosition - initialCarPosition;
		}

		void FixedUpdate()
		{
			if (car == null)
			{
				return;
			}
			
			//Look at car
			Vector3 _lookDirection = (new Vector3(car.transform.position.x, car.transform.position.y, car.transform.position.z)) - transform.position;
			Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
			transform.rotation = Quaternion.Lerp(transform.rotation, _rot, lookSpeed * Time.deltaTime);

			//Move to car
			Vector3 _targetPos = absoluteInitCameraPosition + car.transform.position;
			transform.position = Vector3.Lerp(transform.position, _targetPos, followSpeed * Time.deltaTime);

		}

	}
}
