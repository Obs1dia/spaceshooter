using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {

    public float speed;
    public Transform player;
    private Vector2 direction;
    public float lifeTime;

	// Use this for initialization
	void Start () {
        //Asetetaan suunta
        direction = (player.position - transform.position).normalized;
	}
	
	// Update is called once per frame
	void Update () {
        //Vähennetään elinaikaa
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
        {
            Destroy(gameObject);
        }
        //Liikutetaan meteoriittiä aluksen suuntaan
        direction = (player.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
	}
}
