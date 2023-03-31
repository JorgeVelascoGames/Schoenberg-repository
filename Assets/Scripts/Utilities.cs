using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace VelascoGames.Utilities
{
	public static class Utilities
	{
		/// <summary>
		/// Gets mouse position over a plane in 3D space (perspective camera)
		/// </summary>

		public static Vector3 GetWorldPositionOnPlane(float z)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
			float distance;
			xy.Raycast(ray, out distance);
			return ray.GetPoint(distance);
		}

		/// <summary>		 
		///Gets mouse position on 2D space (ortographic camera)
		/// </summary>
		public static Vector3 GetMousPos()
		{

			Vector3 mousePos = Input.mousePosition;

			Vector3 point = Camera.main.ScreenToWorldPoint(mousePos);

			point = new Vector3(point.x, point.y, 0);

			return point;
		}

		//Shuffle a list
		public static void Shuffle<T>(this IList<T> list)
		{
			System.Random rnd = new System.Random();
			for (var i = 0; i < list.Count; i++)
				list.Swap(i, rnd.Next(i, list.Count));
		}

		//Swap items on a list
		public static void Swap<T>(this IList<T> list, int i, int j)
		{
			var temp = list[i];
			list[i] = list[j];
			list[j] = temp;
		}

		///<summary>
		///Get a percent (int)
		///</summary>
		public static int GetPercent(int number, int percent)
		{
			int temp = (number * percent) / 100;

			return temp;
		}

		///<summary>
		///Get a percent (float)
		///</summary>
		public static float GetPercent(float number, float percent)
		{
			float temp = (number * percent) / 100;

			return temp;
		}

		///<summary>
		///Get distance between two transforms
		///</summary>
		public static float DistanceBetween(Transform point1, Transform point2)
		{
			float distance = Vector3.Distance(point1.position, point2.position);

			return distance;
		}

		///<summary>
		///Get the closest transform from a list
		///</summary>

		public static Transform ClosestTransform(List<Transform> list, Transform actor)
		{
			Transform transformToReturn = list[0];
			foreach(var point in list)
			{
				if(point != transformToReturn)
				{
					if (DistanceBetween(point, actor) < DistanceBetween(transformToReturn, actor))
						transformToReturn = point;
				}
			}

			return transformToReturn;
		}

		///<summary>
		///Get the closest GameObject from any list
		///</summary>
		public static GameObject ClosestGameObject(List<GameObject> list, Transform actor)
		{
			GameObject objectToReturn = list[0];

			foreach (var point in list)
			{
				if (point != objectToReturn)
				{
					if (DistanceBetween(point.transform, actor) < DistanceBetween(objectToReturn.transform, actor))
						objectToReturn = point;
				}
			}

			return objectToReturn;
		}


		///<summary>
		///Select object with Raycast
		///</summary>
		public static GameObject SelectWithRaycast()
		{
			GameObject selection = null;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if(Physics.Raycast(ray, out hit))
			{
				selection = hit.transform.gameObject;
			}


			if (selection != null)
				Debug.Log(selection.name);

			return selection;
		}

		///<summary>
		///Select object with Raycast Ignoring layer
		///</summary>
		public static GameObject SelectWithRaycast(int layerToIgnore)
		{
			GameObject selection = null;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~layerToIgnore))
			{
				selection = hit.transform.gameObject;
			}

			if(selection != null)
				Debug.Log(selection.name);

			return selection;
		}
	}
}

