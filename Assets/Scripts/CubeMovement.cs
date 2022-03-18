using System;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
	private float speed;
	private float distance;
	private Vector3 direction;

	private float passedDistance;

	public void Init(float speed, float distance, Vector3 direction)
	{
		this.speed = speed;
		this.distance = distance;
		this.direction = direction;

		passedDistance = 0f;
	}

	private void Update()
	{
		float deltaMove = speed * Time.deltaTime;
		transform.position += deltaMove * direction;
		passedDistance += deltaMove;

		if (passedDistance >= distance)
		{
			FinishMovement();
		}
	}

	private void FinishMovement()
	{
		Destroy(gameObject);
	}
}
