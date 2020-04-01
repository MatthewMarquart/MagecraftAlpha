using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceBlast : MonoBehaviour
    {

        public float blastForce;
        public float blastRadius;
        public GameObject blastSource;
        public GameObject ForceParticle;
   // public GameObject invokePoint;
    //public GameObject invokeEffect;

    private void Update()
        {
            if (OVRInput.Get(OVRInput.RawButton.RHandTrigger))
            {
                CastSpell();
                GameObject hf = Instantiate(ForceParticle);
                hf.transform.position = blastSource.transform.position;
            //so, similar to the flashpoint spell, this one does the particles even if nothing else is happening
            //it plays the particles at the blastsource location, which is placed on the user's hand


           // GameObject ip = Instantiate(invokeEffect);
//ip.transform.position = invokePoint.transform.position;
        }
        }
        private void CastSpell()
        {
            Collider[] colliders = Physics.OverlapSphere(blastSource.transform.position, blastRadius);
            foreach (Collider pushedObject in colliders)
            {
                if (pushedObject.CompareTag("ForceTarget"))
                {
                    Rigidbody pushedBody = pushedObject.GetComponent<Rigidbody>();
                    pushedBody.AddExplosionForce(blastForce, blastSource.transform.position, blastForce);
                //once the first section is done, the objects within the blastradius around the blastsource are checked for the ForceTarget tag.
                //Anything with the forcetarget tag is moved based on the blastforce amount relative to the blastsource position
                }
            }
        }
    }