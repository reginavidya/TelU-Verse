using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoShared;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace GoMap
{

    public class ClickScript : MonoBehaviour
    {
        public GameObject projectorPrefab;
        private GameObject currentProjector;
        public GOMap goMap;
        public GameObject popUpGKU;
        public GameObject popUpDamar;
        public GameObject popUpAR;
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
        public Button ok;
        int sceneIndex;


        //In the update we detect taps of mouse or touch to trigger a raycast on the ground
        private void Start()
        {
            sceneIndex = SceneManager.GetActiveScene().buildIndex;

            ok.onClick.AddListener(() =>
            {
                popUpAR.SetActive(false);
            });
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(sceneIndex - 3);
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
                        popUpAR.SetActive(false);
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
                        popUpAR.SetActive(false);
                    }
                    else if (hit.collider.name == "AR FIT")
                    {
                        Debug.Log(hit.collider.name);
                        popUpAR.SetActive(true);
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
                        popUpAR.SetActive(true);
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
                        popUpAR.SetActive(true);
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
                        popUpAR.SetActive(true);
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
                        popUpAR.SetActive(true);
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
                        Debug.Log(hit.collider.name);
                        popUpAR.SetActive(true);
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
                        popUpAR.SetActive(false);
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
                        popUpAR.SetActive(false);
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
                        popUpAR.SetActive(false);
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
                        popUpAR.SetActive(false);
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
                        popUpAR.SetActive(false);
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
                        popUpAR.SetActive(false);
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
                        popUpAR.SetActive(false);
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
                        popUpAR.SetActive(false);
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
                        popUpAR.SetActive(false);
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
                        popUpAR.SetActive(false);
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
                        popUpAR.SetActive(false);
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

                    //Add a simple projector to the tapped point
                    currentProjector = GameObject.Instantiate(projectorPrefab);
                    worldVector.y += 5.5f;
                    currentProjector.transform.position = worldVector;
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
    }
}
