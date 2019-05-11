using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
	public GameObject FoodPrefab;

	public Vector2 FieldSize = new Vector2(40, 40);
	public Vector2 FieldPos = new Vector2(-20, 0);

	public void CreateNewFood()
	{
		if (FoodPrefab != null)
		{
			var food = Instantiate(FoodPrefab);
			food.transform.position = new Vector3(FieldPos.x + Random.Range(0, FieldSize.x), 0, FieldPos.y + Random.Range(0, FieldSize.y));
		}

	}

	private void Start()
	{
		CreateNewFood();
		CreateNewFood();
	}
}
