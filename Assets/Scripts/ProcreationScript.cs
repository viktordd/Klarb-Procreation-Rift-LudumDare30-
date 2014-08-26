using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProcreationScript : MonoBehaviour {

    private float yOffset = -50f;
    private List<Quote> quoteList;
    private const float timeBetweenTransition = 2.0f;
    private float counter = 0;
    private int currentIndex = 0;
    private float initialOffset = -100f;

	// Use this for initialization
	void Start () {
        quoteList = getQuoteList();        
	}
	
	// Update is called once per frame
	void Update () {
        counter += Time.deltaTime;
        if (counter > timeBetweenTransition)
        {
            counter = 0;
            if (currentIndex >= quoteList.Count)
            {
                var newLevel = PlayerPrefs.GetInt("LevelNumber") + 1;
                PlayerPrefs.SetInt("LevelNumber", newLevel);
				PlayerPrefs.Save();
                Application.LoadLevel("main");
            }
            writeText(quoteList[currentIndex], currentIndex);
            currentIndex++;
        }
        
	}

    private List<Quote> getQuoteList()
    {
        System.Random rand = new System.Random();
        Quote[] quotes = jokeList[rand.Next(jokeList.Length)];
        List<Quote> qList = new List<Quote>();
        qList.Add(new Quote("The two Klarbs embrace at the middle of the rift", Color.white));
        foreach(Quote q in quotes)
        {
            qList.Add(q);
        }
        qList.Add(new Quote("Two new Klarbs must now attempt to traverse the rift", Color.white));
        return qList;
    }

    private void writeText(Quote q, int textsCreated)
    {
        GameObject go = new GameObject("GUIText " + textsCreated);

        float yPos = (textsCreated * yOffset + initialOffset);
        GUIText text1 = go.AddComponent<GUIText>();
        text1.text = q.Text;
        text1.fontSize = 24;
        text1.color = q.TextColor;
        text1.pixelOffset = new Vector2(100f, yPos);
        text1.alignment = TextAlignment.Left;
        go.transform.parent = this.gameObject.transform;
        go.transform.localPosition = new Vector3(0, 0, 0);
    }

    Quote[][] jokeList = new Quote[][]
    {
        new []{ new Quote("But unfortunately space radiation made the male Klarb sterile.", Color.white)},
        new []{ new Quote("Girl: Is it ok if I imagine you are Justin Klieber?", Color.red), new Quote("Boy: .......no.", Color.blue)},
        new []{ new Quote("But they realize they are siblings. What are the chances?", Color.white)},
        new []{ new Quote("Boy: ...I have to pee.....", Color.blue)},
        new []{ new Quote("Girl: Before we start, I have to tell you......I have Klerpies.", Color.red)},
        new []{ new Quote("Girl: ....Dad?", Color.red)},
        new []{ new Quote("But as much as the male tried, he just couldn't get a klerection.", Color.white)},
        new []{ new Quote("Boy: You look like my mom.", Color.blue), new Quote(" Girl: ...Bye.", Color.red)},
        new []{ new Quote("Girl: hehehehehe", Color.red), new Quote("Boy: HEY! Its really cold in space!", Color.blue)},
        new []{ new Quote("But before they could start.......meteor.", Color.white)},
        new []{ new Quote("But before they could begin, they were mauled by a space bear", Color.white)},
        new []{ new Quote("But they forgot how to procreate", Color.white)},
        new []{ new Quote("But one of the Klarbs had really, really bad breath", Color.white)},
        new []{ new Quote("But one of the Klarbs Mom called and ruined the mood", Color.white)},
        new []{ new Quote("But then both of the Klarbs turned gay", Color.white)},
    };

}
