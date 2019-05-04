using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

	public FoodManager fm = null;

	private void OnCollisionEnter(Collision collision)
	{

		if (collision.gameObject.tag == "Walls")
		{
			
			fm.CreateNewFood();
			Destroy(gameObject);

		}
	}

}
