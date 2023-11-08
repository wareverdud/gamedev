using UnityEngine;
using System.Collections;

public class Flaregun : MonoBehaviour {
	public Rigidbody flareBullet;
	public Transform barrelEnd;
	public GameObject muzzleParticles;
	public int bulletSpeed = 2000;
	public int maxSpareRounds = 5;
	public int spareRounds = 3;
	public int currentRound = 0;
	
	void Update () 
	{
		if(Input.GetButtonDown("Fire1") && !GetComponent<Animation>().isPlaying)
		{
			GetComponent<Animation>().CrossFade("Shoot");
			// GetComponent<AudioSource>().PlayOneShot(flareShotSound);
		
			Rigidbody bulletInstance;			
			bulletInstance = Instantiate(flareBullet,barrelEnd.position,barrelEnd.rotation) as Rigidbody;
			
			bulletInstance.AddForce(barrelEnd.forward * bulletSpeed);
			
			Instantiate(muzzleParticles, barrelEnd.position,barrelEnd.rotation);
		}
	}
}
