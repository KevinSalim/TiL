using UnityEngine;
using System.Collections;
using System.Linq;

public class FlyingBird : MonoBehaviour {

	//Another option on the start method, rather than void Start() is to treat as IEnumerator so we can use Yield with it.
	IEnumerator  Start () {
		//Ge the child gameobject called bird
		var child = transform.Find ("Bird");

		//randomize the animation speeds. Get the 'bird' object's animator component and set its speed.
		var animator = child.GetComponent<Animator>();
		var speed = animator.speed;
		animator.speed = Random.Range (speed - 1, speed + 1);

		//Disable it, so the animations don't run
		child.gameObject.SetActive (false);

		//force a delay
		yield return StartCoroutine ("PauseMe");

		//enable them
		child.gameObject.SetActive (true);
	}

	IEnumerator PauseMe()
	{
		yield return new WaitForSeconds(Random.Range(.3f, 1.3f));
	}

}
