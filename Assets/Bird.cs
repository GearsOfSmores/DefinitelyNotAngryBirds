using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private Vector3 _initialPosition;
    private bool _birdWasLauched;
    private float _timeSittingAround;

    [SerializeField] private float _launchPower = 500;
    

    private void Awake()
        {
            _initialPosition = transform.position;
            
        }
    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
        GetComponent<LineRenderer>().SetPosition(0, transform.position);

        //check if brid was lauched and if velocity is less than .1
        if (_birdWasLauched &&
            GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timeSittingAround += Time.deltaTime;
        }

        if (transform.position.y > 30 ||
            transform.position.y < -10 ||
            transform.position.x > 30 ||
            transform.position.x < -10 ||
            _timeSittingAround > 3)
                
        {
               //use scenemanager to 
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);

        }
    }
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
    }
    private void OnMouseUp()
    {
          //add white arrows to bird
        GetComponent<SpriteRenderer>().color = Color.white;
        GetComponent<LineRenderer>().enabled = false;

        Vector2 directionToInitialPosition = _initialPosition - transform.position;

        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdWasLauched = true;


}
    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
}
