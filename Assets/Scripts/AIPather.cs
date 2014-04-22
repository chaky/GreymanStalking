using UnityEngine;
using System.Collections;
using Pathfinding;

public class AIPather : MonoBehaviour {

	public Transform target;
	Seeker seeker;
	Path path;
	int currentWaypoint;
	float speed = 10f;

	CharacterController characterController;

	void Start() {
		seeker = GetComponent <Seeker> ();
		seeker.StartPath(transform.position, target.position, OnComplete);
		characterController = GetComponent<CharacterController> ();
	}

	public void StartPath() {
		//seeker = GetComponent <Seeker> ();
		//seeker.StartPath(transform.position, target.position, OnComplete);
		Debug.Log ("wa");
	}

	void OnComplete(Path p) {
		if (!p.error) {
			path = p;
			currentWaypoint = 0;
		} else {
			Debug.Log(p.error);
		}
	}

	void FixedUpdate () {
		if (path == null) {
			return;
		}
		if (currentWaypoint >= path.vectorPath.Count) {
			return;
		}
		Vector3 dir = (path.vectorPath [currentWaypoint] - transform.position).normalized * speed;
		characterController.SimpleMove (dir);

		if (Vector3.Distance (transform.position, path.vectorPath [currentWaypoint]) < 1f) {
			currentWaypoint++;
		}
	}
}