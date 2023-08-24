using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoShared;
using UnityEngine.SceneManagement;

namespace GoMap
{

	public class GOCoordinatesRaycast : MonoBehaviour
	{
		private GameObject currentProjector;
		public GOMap goMap;
		public GameObject popUpGKU;
		public GameObject popUpDamar;
		[Header("OBJEK VFX")]
		public GameObject radFik;
		public GameObject radFeb;
		public GameObject radFkb;
		public GameObject radFit;
		public GameObject radTult;
		public GameObject radBangkit;
		[Header("OBJEK INFO")]
		public GameObject infoFik;
		public GameObject infoFeb;
		public GameObject infoFkb;
		public GameObject infoFit;
		public GameObject infoGku;
		public GameObject infoDamar;
		public GameObject infoBangkit;
		public GameObject infoMsu;
		public GameObject infoTuch;
		public GameObject infoAsrama;
		public GameObject infoTult;
		public GOUVMappingStyle uvMappingStyle = GOUVMappingStyle.TopFitSidesRatio;
		public bool debugLog = false;
		public bool atomic = true;
		GameObject radiusFik;
		GameObject radiusFit;
		GameObject radiusFkb;
		GameObject radiusFeb;
		GameObject radiusBangkit;
		GameObject radiusTult;
		int sceneIndex;

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				SceneManager.LoadScene(sceneIndex - 1);
			}

			bool drag = false;
			if (Application.isMobilePlatform)
			{
				drag = Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began;
			}
			else
				drag = Input.GetMouseButton(0) && Input.GetAxisRaw("Mouse X") == 0.0f && Input.GetAxisRaw("Mouse Y") == 0.0f;

			if (drag)
			{

				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out hit, GOMap.GetActiveMasks()))
				{
					if (hit.collider.name == "VR GKU")
					{
						popUpGKU.SetActive(true);
						popUpDamar.SetActive(false);
						Debug.Log(hit.collider.name);
						infoAsrama.SetActive(false);
						infoBangkit.SetActive(false);
						infoDamar.SetActive(false);
						infoFeb.SetActive(false);
						infoFik.SetActive(false);
						infoFit.SetActive(false);
						infoFkb.SetActive(false);
						infoGku.SetActive(false);
						infoMsu.SetActive(false);
						infoTuch.SetActive(false);
						infoTult.SetActive(false);
						radiusFeb.SetActive(false);
						radiusFkb.SetActive(false);
						radiusFik.SetActive(false);
						radiusFit.SetActive(false);
						radiusBangkit.SetActive(false);
						radiusTult.SetActive(false);
					}
					else if (hit.collider.name == "VR DAMAR")
					{
						popUpDamar.SetActive(true);
						popUpGKU.SetActive(false);
						Debug.Log(hit.collider.name);
						infoAsrama.SetActive(false);
						infoBangkit.SetActive(false);
						infoDamar.SetActive(false);
						infoFeb.SetActive(false);
						infoFik.SetActive(false);
						infoFit.SetActive(false);
						infoFkb.SetActive(false);
						infoGku.SetActive(false);
						infoMsu.SetActive(false);
						infoTuch.SetActive(false);
						infoTult.SetActive(false);
						radiusFeb.SetActive(false);
						radiusFkb.SetActive(false);
						radiusFik.SetActive(false);
						radiusFit.SetActive(false);
						radiusBangkit.SetActive(false);
						radiusTult.SetActive(false);
					}
					else if (hit.collider.name == "AR FIT")
					{
						Debug.Log(hit.collider.name);
						radiusFit.SetActive(true);
						radiusFik.SetActive(false);
						radiusFkb.SetActive(false);
						radiusFeb.SetActive(false);
						radiusBangkit.SetActive(false);
						radiusTult.SetActive(false);
						infoAsrama.SetActive(false);
						infoBangkit.SetActive(false);
						infoDamar.SetActive(false);
						infoFeb.SetActive(false);
						infoFik.SetActive(false);
						infoFit.SetActive(false);
						infoFkb.SetActive(false);
						infoGku.SetActive(false);
						infoMsu.SetActive(false);
						infoTuch.SetActive(false);
						infoTult.SetActive(false);
						popUpDamar.SetActive(false);
						popUpGKU.SetActive(false);
					}
					else if (hit.collider.name == "AR FIK")
					{

						Debug.Log(hit.collider.name);
						radiusFik.SetActive(true);
						radiusFit.SetActive(false);
						radiusFkb.SetActive(false);
						radiusFeb.SetActive(false);
						radiusBangkit.SetActive(false);
						radiusTult.SetActive(false);
						infoAsrama.SetActive(false);
						infoBangkit.SetActive(false);
						infoDamar.SetActive(false);
						infoFeb.SetActive(false);
						infoFik.SetActive(false);
						infoFit.SetActive(false);
						infoFkb.SetActive(false);
						infoGku.SetActive(false);
						infoMsu.SetActive(false);
						infoTuch.SetActive(false);
						infoTult.SetActive(false);
						popUpDamar.SetActive(false);
						popUpGKU.SetActive(false);
					}
					else if (hit.collider.name == "AR FKB")
					{
						Debug.Log(hit.collider.name);
						radiusFkb.SetActive(true);
						radiusFeb.SetActive(false);
						radiusFik.SetActive(false);
						radiusFit.SetActive(false);
						radiusBangkit.SetActive(false);
						radiusTult.SetActive(false);
						infoAsrama.SetActive(false);
						infoBangkit.SetActive(false);
						infoDamar.SetActive(false);
						infoFeb.SetActive(false);
						infoFik.SetActive(false);
						infoFit.SetActive(false);
						infoFkb.SetActive(false);
						infoGku.SetActive(false);
						infoMsu.SetActive(false);
						infoTuch.SetActive(false);
						infoTult.SetActive(false);
						popUpDamar.SetActive(false);
						popUpGKU.SetActive(false);
					}
					else if (hit.collider.name == "AR FEB")
					{
						Debug.Log(hit.collider.name);
						radiusFeb.SetActive(true);
						radiusFkb.SetActive(false);
						radiusFik.SetActive(false);
						radiusFit.SetActive(false);
						radiusBangkit.SetActive(false);
						radiusTult.SetActive(false);
						infoAsrama.SetActive(false);
						infoBangkit.SetActive(false);
						infoDamar.SetActive(false);
						infoFeb.SetActive(false);
						infoFik.SetActive(false);
						infoFit.SetActive(false);
						infoFkb.SetActive(false);
						infoGku.SetActive(false);
						infoMsu.SetActive(false);
						infoTuch.SetActive(false);
						infoTult.SetActive(false);
						popUpDamar.SetActive(false);
						popUpGKU.SetActive(false);
					}
					else if (hit.collider.name == "AR TULT")
					{
						Debug.Log(hit.collider.name);
						radiusTult.SetActive(true);
						radiusFik.SetActive(false);
						radiusFit.SetActive(false);
						radiusFkb.SetActive(false);
						radiusFeb.SetActive(false);
						radiusBangkit.SetActive(false);
						infoAsrama.SetActive(false);
						infoBangkit.SetActive(false);
						infoDamar.SetActive(false);
						infoFeb.SetActive(false);
						infoFik.SetActive(false);
						infoFit.SetActive(false);
						infoFkb.SetActive(false);
						infoGku.SetActive(false);
						infoMsu.SetActive(false);
						infoTuch.SetActive(false);
						infoTult.SetActive(false);
						popUpDamar.SetActive(false);
						popUpGKU.SetActive(false);
					}
					else if (hit.collider.name == "AR BANGKIT")
					{
						Debug.Log( hit.collider.name);
						radiusBangkit.SetActive(true);
						radiusFik.SetActive(false);
						radiusFit.SetActive(false);
						radiusFkb.SetActive(false);
						radiusFeb.SetActive(false);
						radiusTult.SetActive(false);
						infoAsrama.SetActive(false);
						infoBangkit.SetActive(false);
						infoDamar.SetActive(false);
						infoFeb.SetActive(false);
						infoFik.SetActive(false);
						infoFit.SetActive(false);
						infoFkb.SetActive(false);
						infoGku.SetActive(false);
						infoMsu.SetActive(false);
						infoTuch.SetActive(false);
						infoTult.SetActive(false);
						popUpDamar.SetActive(false);
						popUpGKU.SetActive(false);
					}
					else if (hit.collider.name == "INFO BANGKIT")
					{
						infoAsrama.SetActive(false);
						infoBangkit.SetActive(true);
						infoDamar.SetActive(false);
						infoFeb.SetActive(false);
						infoFik.SetActive(false);
						infoFit.SetActive(false);
						infoFkb.SetActive(false);
						infoGku.SetActive(false);
						infoMsu.SetActive(false);
						infoTuch.SetActive(false);
						infoTult.SetActive(false);
						radiusFeb.SetActive(false);
						radiusFkb.SetActive(false);
						radiusFik.SetActive(false);
						radiusFit.SetActive(false);
						radiusBangkit.SetActive(false);
						radiusTult.SetActive(false);
						popUpDamar.SetActive(false);
						popUpGKU.SetActive(false);
					}
					else if (hit.collider.name == "INFO ASRAMA")
					{
						infoAsrama.SetActive(true);
						infoBangkit.SetActive(false);
						infoDamar.SetActive(false);
						infoFeb.SetActive(false);
						infoFik.SetActive(false);
						infoFit.SetActive(false);
						infoFkb.SetActive(false);
						infoGku.SetActive(false);
						infoMsu.SetActive(false);
						infoTuch.SetActive(false);
						infoTult.SetActive(false);
						radiusFeb.SetActive(false);
						radiusFkb.SetActive(false);
						radiusFik.SetActive(false);
						radiusFit.SetActive(false);
						radiusBangkit.SetActive(false);
						radiusTult.SetActive(false);
						popUpDamar.SetActive(false);
						popUpGKU.SetActive(false);
					}
					else if (hit.collider.name == "INFO DAMAR")
					{
						infoAsrama.SetActive(false);
						infoBangkit.SetActive(false);
						infoDamar.SetActive(true);
						infoFeb.SetActive(false);
						infoFik.SetActive(false);
						infoFit.SetActive(false);
						infoFkb.SetActive(false);
						infoGku.SetActive(false);
						infoMsu.SetActive(false);
						infoTuch.SetActive(false);
						infoTult.SetActive(false);
						radiusFeb.SetActive(false);
						radiusFkb.SetActive(false);
						radiusFik.SetActive(false);
						radiusFit.SetActive(false);
						radiusBangkit.SetActive(false);
						radiusTult.SetActive(false);
						popUpDamar.SetActive(false);
						popUpGKU.SetActive(false);
					}
					else if (hit.collider.name == "INFO FEB")
					{
						infoAsrama.SetActive(false);
						infoBangkit.SetActive(false);
						infoDamar.SetActive(false);
						infoFeb.SetActive(true);
						infoFik.SetActive(false);
						infoFit.SetActive(false);
						infoFkb.SetActive(false);
						infoGku.SetActive(false);
						infoMsu.SetActive(false);
						infoTuch.SetActive(false);
						infoTult.SetActive(false);
						radiusFeb.SetActive(false);
						radiusFkb.SetActive(false);
						radiusFik.SetActive(false);
						radiusFit.SetActive(false);
						radiusBangkit.SetActive(false);
						radiusTult.SetActive(false);
						popUpDamar.SetActive(false);
						popUpGKU.SetActive(false);
					}
					else if (hit.collider.name == "INFO FIK")
					{
						infoAsrama.SetActive(false);
						infoBangkit.SetActive(false);
						infoDamar.SetActive(false);
						infoFeb.SetActive(false);
						infoFik.SetActive(true);
						infoFit.SetActive(false);
						infoFkb.SetActive(false);
						infoGku.SetActive(false);
						infoMsu.SetActive(false);
						infoTuch.SetActive(false);
						infoTult.SetActive(false);
						radiusFeb.SetActive(false);
						radiusFkb.SetActive(false);
						radiusFik.SetActive(false);
						radiusFit.SetActive(false);
						radiusBangkit.SetActive(false);
						radiusTult.SetActive(false);
						popUpDamar.SetActive(false);
						popUpGKU.SetActive(false);
					}
					else if (hit.collider.name == "INFO FIT")
					{
						infoAsrama.SetActive(false);
						infoBangkit.SetActive(false);
						infoDamar.SetActive(false);
						infoFeb.SetActive(false);
						infoFik.SetActive(false);
						infoFit.SetActive(true);
						infoFkb.SetActive(false);
						infoGku.SetActive(false);
						infoMsu.SetActive(false);
						infoTuch.SetActive(false);
						infoTult.SetActive(false);
						radiusFeb.SetActive(false);
						radiusFkb.SetActive(false);
						radiusFik.SetActive(false);
						radiusFit.SetActive(false);
						radiusBangkit.SetActive(false);
						radiusTult.SetActive(false);
						popUpDamar.SetActive(false);
						popUpGKU.SetActive(false);
					}
					else if (hit.collider.name == "INFO FKB")
					{
						infoAsrama.SetActive(false);
						infoBangkit.SetActive(false);
						infoDamar.SetActive(false);
						infoFeb.SetActive(false);
						infoFik.SetActive(false);
						infoFit.SetActive(false);
						infoFkb.SetActive(true);
						infoGku.SetActive(false);
						infoMsu.SetActive(false);
						infoTuch.SetActive(false);
						infoTult.SetActive(false);
						radiusFeb.SetActive(false);
						radiusFkb.SetActive(false);
						radiusFik.SetActive(false);
						radiusFit.SetActive(false);
						radiusBangkit.SetActive(false);
						radiusTult.SetActive(false);
						popUpDamar.SetActive(false);
						popUpGKU.SetActive(false);
					}
					else if (hit.collider.name == "INFO GKU")
					{
						infoAsrama.SetActive(false);
						infoBangkit.SetActive(false);
						infoDamar.SetActive(false);
						infoFeb.SetActive(false);
						infoFik.SetActive(false);
						infoFit.SetActive(false);
						infoFkb.SetActive(false);
						infoGku.SetActive(true);
						infoMsu.SetActive(false);
						infoTuch.SetActive(false);
						infoTult.SetActive(false);
						radiusFeb.SetActive(false);
						radiusFkb.SetActive(false);
						radiusFik.SetActive(false);
						radiusFit.SetActive(false);
						radiusBangkit.SetActive(false);
						radiusTult.SetActive(false);
						popUpDamar.SetActive(false);
						popUpGKU.SetActive(false);
					}
					else if (hit.collider.name == "INFO MSU")
					{
						infoAsrama.SetActive(false);
						infoBangkit.SetActive(false);
						infoDamar.SetActive(false);
						infoFeb.SetActive(false);
						infoFik.SetActive(false);
						infoFit.SetActive(false);
						infoFkb.SetActive(false);
						infoGku.SetActive(false);
						infoMsu.SetActive(true);
						infoTuch.SetActive(false);
						infoTult.SetActive(false);
						radiusFeb.SetActive(false);
						radiusFkb.SetActive(false);
						radiusFik.SetActive(false);
						radiusFit.SetActive(false);
						radiusBangkit.SetActive(false);
						radiusTult.SetActive(false);
						popUpDamar.SetActive(false);
						popUpGKU.SetActive(false);
					}
					else if (hit.collider.name == "INFO TUCH")
					{
						infoAsrama.SetActive(false);
						infoBangkit.SetActive(false);
						infoDamar.SetActive(false);
						infoFeb.SetActive(false);
						infoFik.SetActive(false);
						infoFit.SetActive(false);
						infoFkb.SetActive(false);
						infoGku.SetActive(false);
						infoMsu.SetActive(false);
						infoTuch.SetActive(true);
						infoTult.SetActive(false);
						radiusFeb.SetActive(false);
						radiusFkb.SetActive(false);
						radiusFik.SetActive(false);
						radiusFit.SetActive(false);
						radiusBangkit.SetActive(false);
						radiusTult.SetActive(false);
						popUpDamar.SetActive(false);
						popUpGKU.SetActive(false);
					}
					else if (hit.collider.name == "INFO TULT")
					{
						infoAsrama.SetActive(false);
						infoBangkit.SetActive(false);
						infoDamar.SetActive(false);
						infoFeb.SetActive(false);
						infoFik.SetActive(false);
						infoFit.SetActive(false);
						infoFkb.SetActive(false);
						infoGku.SetActive(false);
						infoMsu.SetActive(false);
						infoTuch.SetActive(false);
						infoTult.SetActive(true);
						radiusFeb.SetActive(false);
						radiusFkb.SetActive(false);
						radiusFik.SetActive(false);
						radiusFit.SetActive(false);
						radiusBangkit.SetActive(false);
						radiusTult.SetActive(false);
						popUpDamar.SetActive(false);
						popUpGKU.SetActive(false);
					}


					//From the raycast data it's easy to get the vector3 of the hit point 
					Vector3 worldVector = hit.point;
					//And it's just as easy to get the gps coordinate of the hit point.
					Coordinates gpsCoordinates = Coordinates.convertVectorToCoordinates(hit.point);

					if (debugLog)
					{

						//There's a little debug string
						Debug.Log(string.Format("[GOMap] Tap world vector: {0}, GPS Coordinates: {1}", worldVector, gpsCoordinates.toLatLongString()));
						Debug.Log(hit.collider.name);
					}

					if (currentProjector != null && atomic)
						GameObject.Destroy(currentProjector);

				}
			}
		}
		public void BackBtn()
		{
			infoAsrama.SetActive(false);
			infoBangkit.SetActive(false);
			infoDamar.SetActive(false);
			infoFeb.SetActive(false);
			infoFik.SetActive(false);
			infoFit.SetActive(false);
			infoFkb.SetActive(false);
			infoGku.SetActive(false);
			infoMsu.SetActive(false);
			infoTuch.SetActive(false);
			infoTult.SetActive(false);
		}
		IEnumerator Start()
		{
			sceneIndex = SceneManager.GetActiveScene().buildIndex;
			//Wait for the location manager to have the world origin set.
			yield return StartCoroutine(goMap.locationManager.WaitForOriginSet());
			radiusFik = Instantiate(radFik, new Vector3(0, 3, 0), Quaternion.identity);
			radiusFit = Instantiate(radFit, new Vector3(0, 3, 0), Quaternion.identity);
			radiusFkb = Instantiate(radFkb, new Vector3(0, 3, 0), Quaternion.identity);
			radiusFeb = Instantiate(radFeb, new Vector3(0, 3, 0), Quaternion.identity);
			radiusBangkit = Instantiate(radBangkit, new Vector3(-3.5f, 3, -136), Quaternion.identity);
			radiusTult = Instantiate(radTult, new Vector3(0, 3, 0), Quaternion.identity);

			radiusBangkit.SetActive(false);
			radiusFik.SetActive(false);
			radiusFit.SetActive(false);
			radiusFkb.SetActive(false);
			radiusFeb.SetActive(false);
			radiusTult.SetActive(false);

			FKB();
			FEB();
			FIK();
			FIT();
			TULT();
			BANGKIT();
		}

		void FIK()
		{
			Coordinates coordinates = new Coordinates(-6.972216247843014, 107.63152839500823);
			goMap.dropPin(coordinates, radiusFik);
		}
		void FKB()
		{
			Coordinates coordinates = new Coordinates(-6.972356392293039, 107.63270269328919);
			goMap.dropPin(coordinates, radiusFkb);
		}
		void FEB()
		{
			Coordinates coordinates = new Coordinates(-6.971737324635702, 107.63191413304533);
			goMap.dropPin(coordinates, radiusFeb);
		}
		void FIT()
		{
			Coordinates coordinates = new Coordinates(-6.972802672734436, 107.63283079080762);
			goMap.dropPin(coordinates, radiusFit);
		}
		void TULT()
		{
			Coordinates coordinates = new Coordinates(-6.969316644147681, 107.62846538104156);
			goMap.dropPin(coordinates, radiusTult);
		}
		void BANGKIT()
		{
			Coordinates coordinates = new Coordinates(-6.974012656350725, 107.63078177421866);
			goMap.dropPin(coordinates, radiusBangkit);
		}
	}
}
