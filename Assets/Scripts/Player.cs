using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public GameObject _pnjPrefab;
    List<Transform> _listPnj = new List<Transform>();
    Rigidbody2D _rigidbody;
    public float _moveStrengh = 10;
    Vector2 _direction;
    public float _diameter=1;
    public float _lastCollisionTime = 0;
    public float _collisionDelay = 0.5f;
    public float _time = 1000;
    public Text _text;
    public int _score = 0;
    // Start is called before the first frame update
    void Start()
    {
        _lastCollisionTime = -1;
        _listPnj.Add(transform);
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_time >= 0)
        {
            _text.text = "Time: " + _time.ToString() + " Seconde\nScore: "+_score;
            _time -= Time.deltaTime;
        }
        else
        {
            
            SceneManager.LoadScene("SampleScene");

        }
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _direction.Normalize();

        if(_listPnj.Count>1)
        {
            for (int i = 1; i < _listPnj.Count; i++)
            {
                Transform leader= _listPnj[i-1];
                Transform follower = _listPnj[i];
                Vector2 leaderToFollower = (follower.position - leader.position).normalized;


                follower.position = (Vector2)leader.position+(leaderToFollower*_diameter);
            }
        }

    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(_direction * _moveStrengh * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Pnj?
        if (collision.name.StartsWith("Pnj") && Time.time > _lastCollisionTime + _collisionDelay)
        {
            _score = _score + 1;
            // Remove the Pnj
            Destroy(collision.gameObject);
            // Instanciate the pnj behin the player if the list is equal to 0 else behind the last element of the list
            Transform tempPnj = Instantiate(_pnjPrefab, new Vector2(_listPnj[_listPnj.Count - 1].position.x - 2, _listPnj[_listPnj.Count - 1].position.y - 2), Quaternion.identity).transform;
            tempPnj.gameObject.name = ("Follower" + (_listPnj.Count - 1));
            // Add the Pnj in the list
            _listPnj.Add(tempPnj);

            _lastCollisionTime = Time.time;
            
        }


        // Collided with Pnj or Border
        // ToDo 'You lose' screen
    }

}
