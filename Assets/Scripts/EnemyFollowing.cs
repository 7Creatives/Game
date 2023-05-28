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
		public bool IsStop;
		public Animator Anim;

		public bool canFight;

		private void Start() 
		{
			InitialPos = transform.position;
		}

		void Update()
		{ 

			float Dist_ = Vector3.Distance(transform.position,player.transform.position);
			if(!CanChase)
			{
				Anim.Play("Idle_");
				if(Dist_<DistTofollow)
				{
					CanChase = true;
				}

				if(isChasing)
				{
					isChasing = false;
					float Distance =Vector3.Distance(transform.position,InitialPos);
					//stop following
					if(Distance > 1)
					{
						transform.LookAt(InitialPos);
						transform.position = Vector3.Lerp(transform.position,InitialPos,speed*Time.deltaTime);
						Anim.Play("Run_");
					}
					
					if(Distance<.1f)
					{
						Anim.Play("Idle_");
					}
				}
				
			}
			else
			{
				isChasing = true;
				//
				if(Dist_<1.3f)
				{
					if(isChasing)
					{
						IsStop = false;
						if(!IsStop)
						{	
							Anim.Play("Idle_");
							// canFight = true;
							// if(canFight)
							// {

							// }
							// else
							// {

							// }

						}
						IsStop = true;	
						isChasing = false;
					}
					else
					{
						//canFight= false;
					}	
				}
				else
				{
					// if(!isChasing)
					// {
					// 	isChasing = true;
					// }
					Anim.Play("Run_");
				}

				if(Dist_ > DistToStopFollowing)
				{
					CanChase = false;
				}

				if(canFight)
				{
					//Anim.Play("");
				}
				transform.LookAt(player.transform);
				transform.position = Vector3.Lerp(transform.position,player.transform.position,speed*Time.deltaTime);
			}	
			Debug.Log(Dist_);	
		}
	}