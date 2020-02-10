using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

    public float speed;
    public float lifeTime;
    public ParticleSystem meteorExplosion;
    private Rigidbody2D rb2d;
    private AudioSource explosion;
    private Points pointsScript;
    
	// Use this for initialization
	void Start () {
        pointsScript = FindObjectOfType<Points>();
        rb2d = GetComponent<Rigidbody2D>();
        explosion = GetComponents<AudioSource>()[1];
	}
	
	// Update is called once per frame
	void Update () {
        //Liikutetaan ammusta
        rb2d.velocity = transform.rotation * Vector2.up * speed;
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Meteor")
        {
            //Synnytetään räjähdys ja tuhotaan meteoriitti
            if (meteorExplosion)
            {
                ParticleSystem m = (ParticleSystem)Instantiate(meteorExplosion, other.transform.position, other.transform.rotation);
                Destroy(m.gameObject, 0.4f);
            }
            pointsScript.points++;
            Destroy(other.gameObject);
            explosion.Play();
            Destroy(gameObject, 0.5f);
        }
    }
}
