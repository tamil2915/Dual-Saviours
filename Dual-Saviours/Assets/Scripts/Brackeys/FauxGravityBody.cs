using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FauxGravityBody : MonoBehaviour {

	private FauxGravityAttractor attractor;
	private Rigidbody rb;

	public bool placeOnSurface = false;

	public void Start ()
	{
		rb = GetComponent<Rigidbody>();
		attractor = FauxGravityAttractor.instance;
	}
	
	public void FixedUpdate ()
	{
		if (placeOnSurface)
			attractor.PlaceOnSurface(rb);
		else
			attractor.Attract(rb);
	}

}
