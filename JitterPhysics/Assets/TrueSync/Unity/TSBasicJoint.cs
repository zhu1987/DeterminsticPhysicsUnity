﻿using UnityEngine;
using System;
using TrueSync.Physics3D;

namespace TrueSync
{
	public class TSBasicJoint : TrueSyncBehaviour
	{
		BasicJoint3D thisJoint;
		TSRigidBody thisBody;


		[SerializeField]
		TSCollider connectedBody;
		[SerializeField]
		Vector3 anchor;
		[SerializeField]
		Vector3 Axis;
		//[SerializeField]
		//bool useLimits = false;
		[SerializeField]
		LimitElements Limits;
		[SerializeField]
		bool useSpring;
		[SerializeField]
		SpringElements Spring;
		[SerializeField]
		FP breakForce = FP.PositiveInfinity;
		TSVector TSWorldAxis;



		public override void OnSyncedStart ()
		{
			thisBody = GetComponent<TSRigidBody> ();
			IBody3D body1 = GetComponent<TSCollider> ().Body;
			IBody3D body2 = connectedBody.Body;

			Vector3 worldPos = transform.TransformPoint (anchor);
			TSVector TSworldPos = worldPos.ToTSVector ();

			//Vector3 worldAxis = transform.TransformDirection (Axis);
			//TSWorldAxis = worldAxis.ToTSVector ();


			//if (useLimits)
			//    thisJoint = new LimitedHingeJoint(PhysicsWorldManager.instance.GetWorld(), body1, body2, TSworldPos, TSWorldAxis, -Limits.Min, Limits.Max);
			//else
			thisJoint = new BasicJoint3D (PhysicsWorldManager.instance.GetWorld (), body1, body2, TSworldPos);

			//charac joint = new CharacterJoint ();

		}

		public override void OnSyncedUpdate ()
		{
			//if (TSMath.Abs (thisJoint.AppliedImpulse) >= breakForce)//@TODO: Add break torque
			//{
			//	thisJoint.Deactivate ();
			//	Destroy (this);
			//}

		}

		protected virtual void OnDrawGizmosSelected ()
		{
			UnityEditor.Handles.SphereHandleCap (0, transform.TransformPoint (anchor), Quaternion.identity, 0.1f, EventType.Repaint);
			Vector3 v3 = transform.rotation * Axis;
			if (v3 == Vector3.zero)
			{
				return;
			}
			UnityEditor.Handles.ArrowHandleCap (1, transform.TransformPoint (anchor), Quaternion.LookRotation (90 * v3), 1, EventType.Repaint);
		}
	}
}
