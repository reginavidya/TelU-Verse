using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using System.Linq;
using System.Text.RegularExpressions;
using System;
using GoMap;
using System.Collections.Generic;
using UnityEngine.Networking;

namespace GoShared
{

    public class GOToLocationDemo : MonoBehaviour
    {

        public InputField inputField;
        public Button button;
        public GOMap goMap;
        public GameObject addressMenu;
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
        GameObject objek12;
        GameObject objek22;
        GameObject objek1;
        GameObject objek2;
        GameObject objek3;
        GameObject objek4;
        GameObject objek5;
        GameObject objek6;
        GameObject objek7;
        GameObject objek8;
        GameObject objek9;
        GameObject addressTemplate;

        public void Start()
        {
            StartCoroutine(Coroutine());
            addressTemplate = addressMenu.transform.Find("Address template").gameObject;

            inputField.onEndEdit.AddListener(delegate (string text)
            {
                GoToAddress();
            });
        }
        IEnumerator Coroutine()
        {

            //Wait for the location manager to have the world origin set.
            yield return goMap.locationManager.WaitForOriginSet();

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
             objek12 = Instantiate(tuch, new Vector3(0, 7, 0), Quaternion.Euler(0f, -52, 0f));
            Coordinates coordinates = new Coordinates(-6.971904257116672, 107.6307283548462);
            goMap.dropPin(coordinates, objek12);
        }
        void MSU()
        {
             objek22 = Instantiate(msu, new Vector3(0, 7.6f, 0), Quaternion.Euler(0f, 92, 0f));
            Coordinates coordinates = new Coordinates(-6.975810132119295, 107.63215052704972);
            goMap.dropPin(coordinates, objek22);
        }
        void FKBFEB()
        {
             objek1 = Instantiate(febfkb, new Vector3(0, 0, 0), Quaternion.Euler(0f, -145f, 0f));
            Coordinates coordinates = new Coordinates(-6.971706978162355, 107.63246244010355);
            goMap.dropPin(coordinates, objek1);
        }
        void FIK()
        {
             objek2 = Instantiate(fik, new Vector3(0, 0, 0), Quaternion.Euler(0f, -142f, 0f));
            Coordinates coordinates = new Coordinates(-6.971983865317066, 107.63121789512063);
            goMap.dropPin(coordinates, objek2);
        }
        void FIT()
        {
             objek3 = Instantiate(fit, new Vector3(0, 12, 0), Quaternion.Euler(0f, 49f, 0f));
            Coordinates coordinates = new Coordinates(-6.9731588247627565, 107.63259839505052);
            goMap.dropPin(coordinates, objek3);
        }
        void GKU()
        {
             objek4 = Instantiate(gku, new Vector3(-71, 16, -21), Quaternion.Euler(0f, -90.71f, 0f));
            Coordinates coordinates = new Coordinates(-6.972975019179515, 107.62962383032088);
            goMap.dropPin(coordinates, objek4);
        }
        void DAMAR()
        {
            objek5 = Instantiate(damar, new Vector3(0, 0, 0), Quaternion.Euler(0f, -182f, 0f));
            Coordinates coordinates = new Coordinates(-6.974953258047489, 107.62992155054883);
            goMap.dropPin(coordinates, objek5);
        }
        void TULT()
        {
             objek6 = Instantiate(tult, new Vector3(0, -17, 0), Quaternion.Euler(0f, 90f, 0f));
            Coordinates coordinates = new Coordinates(-6.968670818754755, 107.62769333733334);
            goMap.dropPin(coordinates, objek6);
        }
        void BANGKIT()
        {
             objek7 = Instantiate(bangkit, new Vector3(0, 0, 0), Quaternion.Euler(0f, -182f, 0f));
            Coordinates coordinates = new Coordinates(-6.974110613392416, 107.63027112606257);
            goMap.dropPin(coordinates, objek7);
        }
        void ASRAMA1()
        {
             objek8 = Instantiate(asrama1, new Vector3(0, 0, 0), Quaternion.Euler(0f, 0f, 0f));
            Coordinates coordinates = new Coordinates(-6.97332942808319, 107.628943820717);
            goMap.dropPin(coordinates, objek8);
        }
        void ASRAMA()
        {
             objek9 = Instantiate(asrama, new Vector3(0, 0, 0), Quaternion.Euler(0f, 3f, 0f));
            Coordinates coordinates = new Coordinates(-6.9704253943013414, 107.62861428132484);
            goMap.dropPin(coordinates, objek9);
        }
        public void GoToAddress()
        {

            if (inputField.text.Any(char.IsLetter))
            { //Text contains letters
                SearchAddress();
            }
            else if (inputField.text.Contains(","))
            {

                string s = inputField.text;
                Coordinates coords = new Coordinates(inputField.text);

                LocationManager locationManager = (LocationManager)goMap.locationManager;
                locationManager.SetLocation(coords);
                Debug.Log("NewCoords: " + coords.latitude + " " + coords.longitude);
            }
        }

        public void SearchAddress()
        {

            addressMenu.SetActive(false);
            string completeUrl;

            if (goMap.mapType == GOMap.GOMapType.Nextzen)
            {

                string baseUrl = "https://search.mapzen.com/v1/search?";
                string apiKey = goMap.nextzen_api_key;
                string text = inputField.text;
                completeUrl = baseUrl + "&text=" + UnityWebRequest.EscapeURL(text) + "&api_key=" + apiKey;
            }
            else
            {
                string baseUrl = "https://api.mapbox.com/geocoding/v5/mapbox.places/";
                string apiKey = goMap.mapbox_accessToken;
                string text = inputField.text;
                completeUrl = baseUrl + UnityWebRequest.EscapeURL(text) + ".json" + "?access_token=" + apiKey;

                if (goMap.locationManager.currentLocation != null)
                {
                    completeUrl += "&proximity=" + goMap.locationManager.currentLocation.longitude + "%2C" + goMap.locationManager.currentLocation.latitude;
                }
                else if (goMap.locationManager.worldOrigin != null)
                {
                    completeUrl += "&proximity=" + goMap.locationManager.worldOrigin.longitude + "%2C" + goMap.locationManager.worldOrigin.latitude;
                }
            }
            Debug.Log(completeUrl);

            IEnumerator request = GOUrlRequest.jsonRequest(this, completeUrl, false, null, (Dictionary<string, object> response, string error) =>
            {

                if (string.IsNullOrEmpty(error))
                {
                    IList features = (IList)response["features"];
                    LoadChoices(features);
                }

            });

            StartCoroutine(request);
        }

        public void LoadChoices(IList features)
        {

            while (addressMenu.transform.childCount > 1)
            {
                foreach (Transform child in addressMenu.transform)
                {
                    if (!child.gameObject.Equals(addressTemplate))
                    {
                        DestroyImmediate(child.gameObject);
                    }
                }
            }


            for (int i = 0; i < Math.Min(features.Count, 5); i++)
            {

                IDictionary feature = (IDictionary)features[i];

                IDictionary geometry = (IDictionary)feature["geometry"];
                IList coordinates = (IList)geometry["coordinates"];
                GOLocation location = new GOLocation();
                IDictionary properties = (IDictionary)feature["properties"];
                Coordinates coords = new Coordinates(Convert.ToDouble(coordinates[1]), Convert.ToDouble(coordinates[0]), 0);

                if (goMap.mapType == GOMap.GOMapType.Nextzen)
                {
                    location.addressString = (string)properties["label"];
                }
                else
                {
                    location.addressString = (string)feature["matching_place_name"] ?? (string)feature["place_name"];
                }
                location.coordinates = coords;
                location.properties = properties;

                GameObject cell = Instantiate(addressTemplate);
                cell.transform.SetParent(addressMenu.transform);
                cell.transform.GetComponentInChildren<Text>().text = location.addressString;
                cell.name = location.addressString;
                cell.SetActive(true);

                Button btn = cell.GetComponent<Button>();
                btn.onClick.AddListener(() =>
                {
                    LoadLocation(location);
                    Debug.Log("Membuka lokasi");
                });

            }


            addressMenu.SetActive(true);


        }

        public void LoadLocation(GOLocation location)
        {

            inputField.text = location.addressString;
            addressMenu.SetActive(false);
            LocationManager locationManager = (LocationManager)goMap.locationManager;
            locationManager.SetLocation(location.coordinates);
            Destroy(objek12);
            Destroy(objek22);
            Destroy(objek1);
            Destroy(objek2);
            Destroy(objek3);
            Destroy(objek4);
            Destroy(objek5);
            Destroy(objek6);
            Destroy(objek7);
            Destroy(objek8);
            Destroy(objek9);

            StartCoroutine(Coroutine());
        }

    }

    [System.Serializable]
    public class GOLocation
    {

        public Coordinates coordinates;
        public IDictionary properties;
        public string addressString;

    }
}
