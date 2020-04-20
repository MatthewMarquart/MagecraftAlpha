using UnityEngine;

public class FlashPoint : MonoBehaviour
{

    public float damage = 10f;
    public float range = 8f;
    //float flashSpeed = 4000;
    //public GameObject flashBullet;
    public GameObject hitEffect;
    public GameObject invokePoint;
    public GameObject invokeEffect;

    public GameObject Caster;


    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.RawButton.RHandTrigger))
        {
            GameObject ip = Instantiate(invokeEffect);
            ip.transform.position = invokePoint.transform.position;
            CastSpell();
            //this creates the magic particles on the player's hand, but doesn't do anything else unless the raycast hits something
            //this way, you can tell if you are casting the spell, even if nothing else is happening, because this is a raycast based spell
        }

    }
    void CastSpell()
    {
        RaycastHit hit;
        if (Physics.Raycast(Caster.transform.position, Caster.transform.forward, out hit, range))
            //this does a raycast out to the listed range of the spell, from the Caster object's forward orientation. "Caster" is an invisible object attached the player's hand in-game.
        {
            //Debug.Log(hit.transform.name);

            SpellTarget target = hit.transform.GetComponent<SpellTarget>();
            GameObject hf = Instantiate(hitEffect);
            //when the raycast hits an object, the particles are created at the hitpoint location. This lets you cast the spell on anything, even if that object won't take damage,
            //such as the ground, pillars, or other unbreakable terrain
            //it is very fun to use
            hf.transform.position = hit.point;
            
            if (target != null)
            {
                target.TakeDamage(damage);
                //if the target is valid, the target takes damage as listed above
                //The breakable boxes in-game have about 50 hp if I recall, and the damage was set to 1 per tick in-game, though it is 10 in the code here



                /*GameObject tempBullet = Instantiate(flashBullet, transform.position, transform.rotation) as GameObject;
                Rigidbody tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody>();
                tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * flashSpeed);
                Destroy(tempBullet, 3f);
                
                //the above blocked out code was when I was trying something else, but that doesn't matter now

                target.TakeDamage(damage);*/

               


                
            }
        }
    }
}
