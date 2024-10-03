using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

//[RequireComponent(typeof(LineRenderer))]
public class BubbleShooterController : MonoBehaviour {
	
	public bool isAiming;

	private float rotationSpeed = 50.0f;
	private float maxLeftAngle = 85.0f;
	private float maxRightAngle = 275.0f;
	MouseLook mouseLook;
	Vector2 mouseAxis;
    private void Awake()
    {

		
	}
    void Start () {
		isAiming = true;
		mouseLook = FindObjectOfType<MouseLook>();
	}
	void mouseAxisFunc(Vector2 axis )
    {
		//mouseAxis = axis;
    }
	void Update () {
		if (isAiming && mouseLook.lookAction !=null){
            //float mouseAxisX = Input.GetAxis("Mouse X");

            Vector2 mousevalue = mouseLook.lookAction.ReadValue<Vector2>();

            float mouseAxisX = mousevalue.x;

            transform.Rotate(Vector3.back * mouseAxisX * this.rotationSpeed * Time.deltaTime);
			if (transform.eulerAngles.z > this.maxLeftAngle && transform.eulerAngles.z < 180.0 ){
				transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y, maxLeftAngle);
			}
			if (transform.eulerAngles.z < this.maxRightAngle && transform.eulerAngles.z > 180.0 ){
				transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y, maxRightAngle);
			}
		}
	}
}
