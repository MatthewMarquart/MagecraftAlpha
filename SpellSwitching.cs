using UnityEngine;

public class SpellSwitching : MonoBehaviour
{

    public int selectedSpell = 0;
    // Start is called before the first frame update
    private bool hasSwitched = false;
    void Start()
    {
        SelectSpell();
        
    }

    // Update is called once per frame
    void Update()
    {
        //this is a long one, but essentially how it works is if the switch button is pressed, and it has not already been switched recently
        //it will cycle through the selectedspell index, which is a list of items which are held in the player's off hand
        //the new selected one will be activated, and the previous selected one will be deactivated
        //each of these objects has their respective spells simply attached to those objects, so it is not necessary to disable the spell code as well
        int previousSelectedSpell = selectedSpell;
        if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger) & !hasSwitched)
        {
            hasSwitched = true;
            if (selectedSpell >= transform.childCount - 1)
                selectedSpell = 0;
            else
            selectedSpell++;
        }

        if (OVRInput.Get(OVRInput.RawButton.LHandTrigger) && !hasSwitched)
        {
            hasSwitched = true;
            if (selectedSpell <= 0)
                selectedSpell = transform.childCount - 1;
            else
                selectedSpell--;
            //similar to above, but this one moves BACK through the index
        }

        if (!OVRInput.Get(OVRInput.RawButton.LHandTrigger) && !OVRInput.Get(OVRInput.RawButton.LIndexTrigger)) {
            hasSwitched = false; }
           
        if (previousSelectedSpell != selectedSpell)
        {
            SelectSpell();
        }
    }

    void SelectSpell()
    {
        int i = 0;
        foreach(Transform spell in transform)
        {
            if (i == selectedSpell)
                spell.gameObject.SetActive(true);
            else
                spell.gameObject.SetActive(false);
            i++;
        }
        //as explained above, this is just where the gameobjects are set active or not
    }
}
