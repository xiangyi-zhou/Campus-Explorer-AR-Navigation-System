using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ARMange : MonoBehaviour {

	public List<PlaceInfo> places = new List<PlaceInfo>();
	public GameObject perfab;
	public PlaceInfo location = new PlaceInfo ();
	public PlaceInfo info = new PlaceInfo();

	private void Start()
    {
		EventCenter.AddListener(EventDefine.SendInfoToPOI, ReceiveInfo);

		location.Latitude= 30.481251;
		location.Longitude = 114.307805;
		// 30.480759,114.312867
		//30.481251,114.307805
		info.Name = "-东门-";
		info.Latitude = 30.480759;
		info.Longitude = 114.312867;

		info.Distance= (float)Distance.MapHelper.GetPointDistance("30.480759,114.312867", "30.481251,114.307805");
		Debug.Log("distance"+info.Distance);

		places.Add(info);
		ShowPlaces();
	}
	public void ReceiveInfo()
    {
		info.Name = SearchBar.inputInfo.Name;
		info.Latitude = SearchBar.inputInfo.Latitude;
		info.Longitude = SearchBar.inputInfo.Longitude;

		info.Distance = (float)Distance.MapHelper.GetPointDistance(location.Latitude.ToString() + "," + location.Longitude.ToString(),
			info.Latitude.ToString() + "," + info.Longitude.ToString());
		Debug.Log("distance" + info.Distance);

		ResetPOI();
	}
	public void ResetPOI()
    {
		places.Add(info);
		ShowPlaces();
	}

	public void ShowPlaces(){
		ClearPlace ();

		for (int i = 0; i < places.Count; i++) {

			GameObject newPlace = Instantiate<GameObject> (perfab);
			newPlace.transform.parent = this.transform;

			double posZ = places [i].Latitude - location.Latitude;
			double posX = places [i].Longitude - location.Longitude;

			float z = 0;
			float x = 0;
			float y = 0;

			if (posZ > 0) {
				z = 500f;
			} else {
				z = -500f;
			}

			if (posX > 0) {
				x = 500f;
			} else {
				x = -500f;
			}

			z = z + (float)(posZ * 1000);
			x = x + (float)(posX * 1000);
			y = y + i * 20;

			newPlace.transform.position = new Vector3 (x, y, z);
			newPlace.transform.LookAt (this.transform);
			newPlace.transform.Rotate (new Vector3 (0f, 180f, 0f));

			newPlace.gameObject.GetComponentInChildren<Text> ().text = places [i].Name + "\n" + places[i].Distance + "m";
		}
	}

	private void ClearPlace(){
		GameObject[] oldPlaces = GameObject.FindGameObjectsWithTag ("Place");
		for (int i = 0; i < oldPlaces.Length; i++) {
			Destroy (oldPlaces [i].gameObject);
		}
	}

}
