using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public class EnemyFollowing : MonoBehaviour
	{
		public int speed;
		public GameObject player;
		Vector3 InitialPos;

		public float DistTofollow;
		public float DistToStopFollowing;

		public bool CanChase;
		public bool isChasing;
		public Animator Anim;

		private void Start() 
		{
			InitialPos = transform.position;
		}

		void Update()
		{ 
			float Dist_ = Vector3.Distance(transform.position,player.transform.position);
			if(Dist_<DistTofollow)
			{
				CanChase = true;
			}		
			
			if(CanChase)
			{
				isChasing = true;
				Anim.Play("Run_");
				transform.LookAt(player.transform);
				transform.position = Vector3.Lerp(transform.position,player.transform.position,speed*Time.deltaTime);
			}
			else
			{
				if(Dist_  > DistToStopFollowing)
				{
					if(isChasing)
					{
						isChasing = false;
						transform.LookAt(InitialPos);
						//stop following
						transform.position = Vector3.Lerp(transform.position,InitialPos,speed*Time.deltaTime);
						Anim.Play("Run_");
					}
				}
			}
		}
	}