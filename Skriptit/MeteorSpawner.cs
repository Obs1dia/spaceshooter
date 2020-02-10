using UnityEngine;
using System.Collections;

public class MeteorSpawner : MonoBehaviour {

    public GameObject Meteor;
    public float spawnTimer;
    public float maxDistance;
    public float minDistance;
    private float timer;
    private float x;
    private float y;

	// Use this for initialization
	void Start () {
        timer = spawnTimer;
        /*
        for (int i = 0; i < 10; i++)
        {
            Spawn();
        }
        */
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Spawn();
            timer = spawnTimer;
        }
	}

    public void Spawn()
    {
        x = 0;
        y = 0;
        //Synnytetään meteoriitti satunnaiseen paikkaan
        while (x < minDistance && x > -minDistance || y < minDistance && y > -minDistance) {
            x = Random.Range(-maxDistance, maxDistance);
            y = Random.Range(-maxDistance, maxDistance);
        }
        GameObject m = (GameObject)Instantiate(Meteor, new Vector2(transform.parent.position.x + x, transform.parent.position.y + y), transform.rotation);
        m.GetComponent<Meteor>().player = transform.parent;
    }
}
