using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _cloudParticlePrefab;
    
    //pass us collision info in collision2D object 'collision'
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bird bird = collision.collider.GetComponent<Bird>();

        //checking if collision was with bird
        if (bird !=null || collision.contacts[0].normal.y < -0.5)
        {
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);

            //adding points after death
            ScoreManager.instance.AddPoint();
                return;
        }

        //to check if collision was with an enemy
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            return;
        }

        //to check if collision occured on the top
        //contacts references the first contact '0', .normal gives angle we hit from and returns x/y value
        //if (collision.contacts[0].normal.y < - 0.5)
        {
            //Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);

           // ScoreManager.instance.AddPoint();
           // Destroy(gameObject);
        }
    }
}
