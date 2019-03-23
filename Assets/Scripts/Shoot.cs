using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shoot : MonoBehaviour {
	public Animation anim;
	public bool ifShooting;
	public AudioSource aud;
	public AudioSource aud2;
    public AudioSource aud3;
    public AudioSource aud4;
	private float frameShotCount = 9;
    private bool isEquipped = false;

	public float damage = 10f;
	public float range = 100f;
	public Camera Cam;
	public float AmountOfBullets = 30;
	public Text AmmoCountText;
	public bool ifAmmoRemaining;

	// Use this for initialization
	void Start () {
		ifShooting = false;
		aud.GetComponent<AudioSource> ();
		aud2.GetComponent<AudioSource> ();
        aud3.GetComponent<AudioSource>();
        aud4.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("2")) {
            if(isEquipped == false) {
                aud.mute = !aud.mute;

            }
            isEquipped = true;
        }
        else if(Input.GetKeyDown("1")) {
            if(isEquipped == true) {
                aud.mute = !aud.mute;
                isEquipped = false;

            }

        }


        if (AmountOfBullets == 0)
        {
            ifAmmoRemaining = false;
            aud = aud2;
            //aud2.Play();
            //AmountOfBullets = 5;
            anim.Stop();
        }
        if(AmountOfBullets <= -2) {
            AmountOfBullets += 1;
        }

        if (AmountOfBullets > 0)
        {
            aud = aud4;
            ifAmmoRemaining = true;

            
        }



        if (isEquipped == false) {
			AmmoCountText.text = AmountOfBullets + "/30";
            if (Input.GetKeyDown("r"))
            {
                AmountOfBullets = 30;
                aud3.Play();

            }

            if (Input.GetKeyDown("v")) {
                AmountOfBullets = 10000;
            }
        }


        //frameShotCount = frameShotCount * Time.deltaTime;

		if (Input.GetMouseButton (0)) {
			ifShooting = true;
			anim.Play ();
			frameShotCount += 1;
		}
		if (Input.GetMouseButtonUp (0) && ifShooting == true) {
			ifShooting = false;
			anim.Stop ();
			aud.Stop ();
            frameShotCount = 14;
		}
		if (frameShotCount == 15) {

            if(ifAmmoRemaining == false) {
                aud2.Play();
            }
            else if(ifAmmoRemaining == true) {
                aud.Play();
            }
			if(isEquipped == false) {
				AmountOfBullets -=1;
			}
			if(isEquipped == true) {
				AmountOfBullets = AmountOfBullets;
			}
			
		}
		if(frameShotCount >= 20) {
			frameShotCount = 1;
		}

        if(Input.GetButton("Fire1") && frameShotCount == 15 && isEquipped == false && AmountOfBullets > 0) {
			ShootGun();
		}
		

	}
	void ShootGun() {
		RaycastHit hit;
		if(Physics.Raycast(Cam.transform.position, Cam.transform.forward,out hit)) {
            Debug.Log(hit.transform.name);
            RaycastTargetHit target = hit.transform.GetComponent<RaycastTargetHit>();
			if(target != null && isEquipped == false) {
				target.TakeDamage(damage);
			}
		}
	}
}
