using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public class EnemyFollowing : MonoBehaviour
	{
		public GameObject Player;
		public float moveSpeed;
		public bool chasing;
		public float distanceToChase = 10f;
		public float distanceToLose = 15f;
		public float distanceToStop = 2f;
		public float distanceToFight = 1f;
		private Vector3 targetPoint;
		private Vector3 startPoint;

		public float keepChasingTime;
   		private float chaseCounter;

    	public Animator anim;

		private void Start() 
		{
			startPoint =transform.position;
		}

		void Update()
		{ 
			if(GetComponent<EnemyHealth>().isEnemyDead)
			{
				chasing = false;
				targetPoint = transform.position;
			}
			else
			{
				targetPoint = Player.transform.position;
        		targetPoint.y = transform.position.y;
			}



			if(!chasing)
			{
				if(Vector3.Distance(transform.position, targetPoint) < distanceToChase)
				{
					chasing = true;
					anim.Play("Run_");
					transform.position = Vector3.Lerp(transform.position,targetPoint+ new Vector3(0, 0, 0),moveSpeed*Time.deltaTime);

				}

				if(chaseCounter > 0)
				{
					chaseCounter -= Time.deltaTime;
					if(chaseCounter <= 0)
					{
						targetPoint = startPoint;
						anim.Play("Run_");
						transform.position = Vector3.Lerp(transform.position,startPoint,moveSpeed*Time.deltaTime);
					}
				}
			}
			else
			{
				if(Vector3.Distance(transform.position, targetPoint) > distanceToStop)
				{
					Player.transform.position = targetPoint;
					FaceTarget();
					anim.Play("Run_");
					transform.position = Vector3.Lerp(transform.position,targetPoint,moveSpeed*Time.deltaTime);
				}
				else 
				{
					FaceTarget();
					anim.Play("Idle_");
					targetPoint = Player.transform.position;
					// float Dist = Vector3.Distance(transform.position,targetPoint);
					// if(Dist<1.5f)
					// {
					// 	if(GetComponentInChildren<EnemyHealth>().isEnemyDead)
					// 	{

					// 	}
					// 	else
					// 	{
					// 		//stop
					// 		transform.position = Player.transform.position + Player.transform.InverseTransformDirection(0,0,1.2f);
					// 	} 
					// }
				} 

				if(Vector3.Distance(transform.position, targetPoint) > distanceToLose)
				{
					chasing = false;
					FaceTarget();
					chaseCounter = keepChasingTime;

				}
			}

			
		}

		void FaceTarget()
		{
			transform.LookAt(Player.transform.position);
		}
	}