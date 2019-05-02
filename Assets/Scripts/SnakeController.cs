﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
	public List<Transform> Tails;
	[Range(0, 3)]
	public float BonesDistance;
	[Range (0, 4)]
	public float Speed;
	public GameObject BonePrefab;
	private Transform _transform;

	private void Start()
	{
		_transform = GetComponent<Transform>();
	}

	private void Update()
	{
		MoveSnake(_transform.position + transform.forward * Speed);

		float angel = Input.GetAxis("Horizontal") * 4;
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
		}
	}
}