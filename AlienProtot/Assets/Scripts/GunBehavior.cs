using UnityEngine;

public class GunBehavior : MonoBehaviour
{

    Vector3 lookPos; // position in world where mouse is (ignoring z)

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleLookPosAndAim();

        //HandleWeaponAim();
        

    }

    /*private void HandleWeaponAim() // Discarded for now
    {
        Vector3 directionToLook = lookPos - transform.position; // creates Vector3 equal to the lookPos - the weapon's position in the world

        directionToLook.y = 0f; // sets the y of direction to look to 0 so now it should be Vector3 (lookPos.x, 0, "0")
        Quaternion targetRotation = Quaternion.LookRotation(directionToLook);// creates a quternion(rotation) equal to the forward of  

        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime*15);
    }*/

    private void HandleLookPosAndAim()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // create a ray (called ray) from camera to point in world (translated from mouse position)

        RaycastHit hit; //create a hit (like a collision ish)

        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) // creates/checks a ray(ray) assigning the objet it hits to hit, from ray to infinity
        {
            Vector3 lookP = hit.point; //assings position in world of point of object hit by ray into a Vector3
            lookP.z = transform.position.z; // sets the z variable of this Vector3 to be the same as the weapon(object with the script)

            lookPos = lookP;
        }
        transform.LookAt(lookPos);

    }
}
