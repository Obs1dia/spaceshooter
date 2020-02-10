using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Spaceship : MonoBehaviour {

    public Text hpText;
    public float speed;
    public float rotationSpeed;
    public int hp;
    private Rigidbody2D rb2d;
    private float rotation;
    public ParticleSystem fireParticle;
    public ParticleSystem explosionParticle;
    private AudioSource spaceshipSound;
    public GameObject missile;
    public Transform missileSpawnPoint;
	// Use this for initialization
	void Start () {
        hp = 100;
        rb2d = GetComponent<Rigidbody2D>();
        spaceshipSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        //Kamera seuraa pelaajaa
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 10);
        if (hpText)
        {
            hpText.text = "HP: " + hp.ToString();
        }
        if (hp <= 0)
        {
            if (explosionParticle)
            {
                Instantiate(explosionParticle, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
        //Liikkuminen
	    if (Input.GetKey(KeyCode.UpArrow))
        {
            rb2d.velocity = transform.rotation * Vector2.up * speed;
            if (!spaceshipSound.isPlaying)
            {
                spaceshipSound.Play();
            }
            //Liekki päälle
            if (fireParticle != null)
            {
                fireParticle.Emit(1);
            }
        }
        else
        {
            spaceshipSound.Stop();
            //Liekki pois päältä
            if (fireParticle != null)
            {
                fireParticle.Stop();
            }
        }
        //Käännetään alusta
        rotation = -Input.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0, 0, rotation) * Time.deltaTime * rotationSpeed);
        //Ampuminen
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
	}

    public void Shoot()
    {
        if (missile != null && missileSpawnPoint != null)
        {
            //Synnytetään ammus
            Instantiate(missile, missileSpawnPoint.position, transform.rotation);
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        //Meteoriitti osuu alukseen
        if (other.tag == "Meteor")
        {
            hp -= 25;
            Destroy(other.gameObject);
        }
    }
}
