using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

    private Renderer background;
    public Transform player;
    private float y_offset;
    private float x_offset;

	// Use this for initialization
	void Start () {
        background = GetComponent<Renderer>();
        x_offset = player.transform.position.x;
        y_offset = player.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        if (player)
        {
            //Liikutetaan taivasta suhteessa pelaajan paikkaan
            transform.position = new Vector2(player.position.x, player.position.y);
            if (player.transform.position.x != x_offset || player.transform.position.y != y_offset)
            {
                background.material.mainTextureOffset += new Vector2(player.transform.position.x - x_offset, player.transform.position.y - y_offset) / 10;

                x_offset = player.transform.position.x;
                y_offset = player.transform.position.y;
            }
        }
	}
}
