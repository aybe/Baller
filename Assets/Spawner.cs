using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject ballPrefab;
	float minZ = -3.4f;
	float maxZ = 3.27f;
	
	float lastSpawnTime = 0;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	float elapsedTime = 0;
	void Update () {
		elapsedTime += Time.deltaTime;
		if ( Input.touchCount != 0 )
		{
			Touch touch = Input.touches[0];
			Ray touchRay = Camera.main.ScreenPointToRay(touch.position);
			
			RaycastHit[] hits = Physics.RaycastAll(touchRay);
			foreach( RaycastHit hit in hits ) {
				
				if (hit.transform.name == "Ramp1") {
					SpawnBallAtPos1(hit.point);
				}
				if (hit.transform.name == "Ramp2") {
					SpawnBallAtPos2(hit.point);
				}
				
			}
		}
		
		if (Input.GetMouseButtonDown(0)) {
			Ray touchRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			RaycastHit[] hits = Physics.RaycastAll(touchRay);
			foreach( RaycastHit hit in hits ) {
				if (hit.transform.name == "Ramp1") {
					SpawnBallAtPos1(hit.point);
				}
				if (hit.transform.name == "Ramp2") {
					SpawnBallAtPos2(hit.point);
				}			
			}
		}
	}
	
	
	void SpawnBallAtPos1(Vector3 pos) {
		
//		Debug.Log("elapsedTime: " + elapsedTime);
		if (elapsedTime < 0.1f) {
			return;
		}
		elapsedTime = 0;			
		
		pos.x = -7.36f;
		pos.y = 6.64f;
		if (pos.z < minZ) {
			pos.z = minZ;
		}
		if (pos.z > maxZ) {
			pos.z = maxZ;
		}
		GameObject clone = Instantiate(ballPrefab, pos, Quaternion.identity) as GameObject;
		clone.GetComponent<Rigidbody>().AddForce(new Vector3(0,-300,0));
	}
	
	void SpawnBallAtPos2(Vector3 pos) {
//		Debug.Log("elapsedTime: " + elapsedTime);
		if (elapsedTime < 0.1f) {
			return;
		}
		elapsedTime = 0;	
		
		pos.y = 6.64f;
		pos.z = 6.66f;
		if (pos.x < -3.89f) {
			pos.x = -3.89f;
		}
		if (pos.x > 3.22f) {
			pos.x = 3.22f;
		}
		GameObject clone = Instantiate(ballPrefab, pos, Quaternion.identity) as GameObject;
		clone.GetComponent<Rigidbody>().AddForce(new Vector3(0,-300,0));
	}
	
}
