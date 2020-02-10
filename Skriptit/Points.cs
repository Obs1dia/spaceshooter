using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Points : MonoBehaviour {

    private Text pointsText;
    public int points;

	// Use this for initialization
	void Start () {
        points = 0;
        pointsText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        pointsText.text = "Pisteet: " + points.ToString();
	}
}
