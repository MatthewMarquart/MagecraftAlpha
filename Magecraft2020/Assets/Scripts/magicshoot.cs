
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicshoot : MonoBehaviour
{
    float bulletSpeed = 2000;
    public GameObject bullet;
    public GameObject bulletCaster;
    public GameObject channelingEffect;
    public GameObject castSource;

    AudioSource bulletAudio;

    // Use this for initialization
    void Start()
    {

        bulletAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.RawButton.RHandTrigger))
        {
            GameObject hf = Instantiate(channelingEffect);
            hf.transform.position = castSource.transform.position;
            if (!IsInvoking("FireBullet"))
            {
                

                InvokeRepeating("FireBullet", 1f, 1f);
            }
            //this is basically an if statement using the OVR stuff, if the process is being invoked, it is continuously run. The numbers 1f/1f are the startup time, and then the repeat time.
            //Right now these numbers are the same, so it feels consistent, but this code sets the foundation for similar spells that may benefit from a longer windup time, or a faster cast time.
        }
        
        else
        {
            CancelInvoke("FireBullet");
        }
    }

    void FireBullet()
    {
        GameObject tempBullet = Instantiate(bullet, bulletCaster.transform.position, bulletCaster.transform.rotation) as GameObject;
        Rigidbody tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody>();
        tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * bulletSpeed);
        Destroy(tempBullet, 3f);
        
        //essentially what this is doing is creating a temporary instance of the prefab bullet object attached to the source, in this case, the icebolt
        //it then makes that temp bullet move forward at bulletSpeed, and then after some time has passed, the bullet it destroyed.
        //this is very simple projectile spell code, but can easily be repurposed for other bullet types, such as other elements, or be modified for size
        //or even become something like a grenade spell with just a few changes.

        //Play Audio
        bulletAudio.Play();
    }

    //void oncolli

}