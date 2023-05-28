using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public class EnemyFollowing : MonoBehaviour
	{
		public int speed;
		public GameObject player;

		void Update()
		{
		    transform.Rotate(180, 0, 0

		   Vector3 localPosition = player.transform.position - transform.position;
			localPosition = localPosition.normalized; 
			transform.Translate(localPosition.x * Time.deltaTime * speed, localPosition.y * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
		}
	}