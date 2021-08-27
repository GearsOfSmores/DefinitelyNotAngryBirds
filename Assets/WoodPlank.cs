
using System;
using UnityEngine;

public class WoodPlank : MonoBehaviour
{
    
    //creating reference to the destructable game object
    [SerializeField] UnityEngine.Object destructableRef;

    //referencing the particlePrefab game object
   // [SerializeField] private GameObject _woodParticlePrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bird bird = collision.collider.GetComponent<Bird>();

        //checking if collision was with bird
        if (bird != null && GetComponent<Rigidbody2D>().velocity.magnitude >= 5)
        {
            //telling game to spawn the Prefab and using transform.position to spawn where the woodPlank is
            //Quaternion means just default rotation
            //Instantiate(_woodParticlePrefab, transform.position, Quaternion.identity);

            

            ExplodeThisGameObject();
            return;
        }

    }

    private void ExplodeThisGameObject()
    {

        //Load destructable game object 
        GameObject destructable = (GameObject)Instantiate(destructableRef);

        destructable.transform.position = transform.position;

        Destroy(gameObject);
    }
}
