using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SnakeController : MonoBehaviour
{
	public List<Transform> Tails;
	[Range(0, 3)]
	public float BonesDistance;
	[Range (0, 8)]
	public float Speed;
	[Range(0, 360)]
	public float RotationSpeed = 4.0f;
	public float Acceleration = 0.015f;
	public GameObject BonePrefab;

	private Transform _transform;

	public UnityEvent OnEat;
    public UnityEvent OnDead;

    private void Start()
	{
		_transform = GetComponent<Transform>();
	}

	private void Update()
	{
		MoveSnake(_transform.position + transform.forward * Speed * Time.deltaTime);

        float angel = Input.GetAxis("Horizontal") * RotationSpeed * Time.deltaTime;
		_transform.Rotate(0, angel, 0);
	}

	private void MoveSnake (Vector3 newPosition)
	{
		float sqrDistance = BonesDistance * BonesDistance;
		Vector3 PreviousPosition = _transform.position;

		foreach (var bone in Tails)
			if ((bone.position - PreviousPosition).sqrMagnitude > sqrDistance )
			{
				var temp = bone.position;
				bone.position = PreviousPosition;
				PreviousPosition = temp;
			}
			else
			{
				break;
			}

		_transform.position = newPosition;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Food")
		{
			Destroy(collision.gameObject);

			var bone = Instantiate(BonePrefab);
			Tails.Add(bone.transform);

			if(OnEat != null)
			{
				OnEat.Invoke();
			}

			Speed += Acceleration;
		}

		if(collision.gameObject.tag == "Walls")
		{
            if (OnDead != null)
            {
                OnDead.Invoke();
            }

        }
    }
}
