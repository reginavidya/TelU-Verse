using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoShared;

namespace GoMap { 
public class DropFeaturesScript : MonoBehaviour
{
		public GOMap goMap;
		[Header("OBJEK 3D")]
		public GameObject febfkb;
		public GameObject fik;
		public GameObject fit;
		public GameObject gku;
		public GameObject damar;
		public GameObject tult;
		public GameObject bangkit;
		public GameObject tuch;
		public GameObject msu;
		public GameObject asrama1;
		public GameObject asrama;

		public GOUVMappingStyle uvMappingStyle = GOUVMappingStyle.TopFitSidesRatio;
		// Use this for initialization
		IEnumerator Start()
		{

			//Wait for the location manager to have the world origin set.
			yield return StartCoroutine(goMap.locationManager.WaitForOriginSet());
			FKBFEB();
			FIK();
			FIT();
			GKU();
			DAMAR();
			TULT();
			BANGKIT();
			TUCH();
			MSU();
			ASRAMA1();
			ASRAMA();
		}
		void TUCH()
		{
			GameObject objek12 = Instantiate(tuch, new Vector3(0, 7, 0), Quaternion.Euler(0f, -52, 0f));
			Coordinates coordinates = new Coordinates(-6.971904257116672, 107.6307283548462);
			goMap.dropPin(coordinates, objek12);
		}
		void MSU()
		{
			GameObject objek22 = Instantiate(msu, new Vector3(0, 7.6f, 0), Quaternion.Euler(0f, 92, 0f));
			Coordinates coordinates = new Coordinates(-6.975810132119295, 107.63215052704972);
			goMap.dropPin(coordinates, objek22);
		}
		void FKBFEB()
		{
			GameObject objek1 = Instantiate(febfkb, new Vector3(0, 0, 0), Quaternion.Euler(0f, -145f, 0f));
			Coordinates coordinates = new Coordinates(-6.971706978162355, 107.63246244010355);
			goMap.dropPin(coordinates, objek1);
		}
		void FIK()
		{
			GameObject objek2 = Instantiate(fik, new Vector3(0, 0, 0), Quaternion.Euler(0f, -142f, 0f));
			Coordinates coordinates = new Coordinates(-6.971983865317066, 107.63121789512063);
			goMap.dropPin(coordinates, objek2);
		}
		void FIT()
		{
			GameObject objek3 = Instantiate(fit, new Vector3(0, 12, 0), Quaternion.Euler(0f, 49f, 0f));
			Coordinates coordinates = new Coordinates(-6.9731588247627565, 107.63259839505052);
			goMap.dropPin(coordinates, objek3);
		}
		void GKU()
		{
			GameObject objek4 = Instantiate(gku, new Vector3(-71, 16, -21), Quaternion.Euler(0f, -90.71f, 0f));
			Coordinates coordinates = new Coordinates(-6.972975019179515, 107.62962383032088);
			goMap.dropPin(coordinates, objek4);
		}
		void DAMAR()
		{
			GameObject objek5 = Instantiate(damar, new Vector3(0, 0, 0), Quaternion.Euler(0f, -182f, 0f));
			Coordinates coordinates = new Coordinates(-6.974953258047489, 107.62992155054883);
			goMap.dropPin(coordinates, objek5);
		}
		void TULT()
		{
			GameObject objek6 = Instantiate(tult, new Vector3(0, -17, 0), Quaternion.Euler(0f, 90f, 0f));
			Coordinates coordinates = new Coordinates(-6.968670818754755, 107.62769333733334);
			goMap.dropPin(coordinates, objek6);
		}
		void BANGKIT()
		{
			GameObject objek7 = Instantiate(bangkit, new Vector3(0, 0, 0), Quaternion.Euler(0f, -182f, 0f));
			Coordinates coordinates = new Coordinates(-6.974110613392416, 107.63027112606257);
			goMap.dropPin(coordinates, objek7);
		}
		void ASRAMA1()
		{
			GameObject objek8 = Instantiate(asrama1, new Vector3(0, 0, 0), Quaternion.Euler(0f, 0f, 0f));
			Coordinates coordinates = new Coordinates(-6.97332942808319, 107.628943820717);
			goMap.dropPin(coordinates, objek8);
		}
		void ASRAMA()
		{
			GameObject objek9 = Instantiate(asrama, new Vector3(0, 0, 0), Quaternion.Euler(0f, 3f, 0f));
			Coordinates coordinates = new Coordinates(-6.9704253943013414, 107.62861428132484);
			goMap.dropPin(coordinates, objek9);
		}
	}
}