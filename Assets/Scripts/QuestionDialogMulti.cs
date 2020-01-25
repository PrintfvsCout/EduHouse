using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class QuestionDialogMulti : QuestionDialogBase {

	// Prefab za toa kako izgleda eden odgovor
	public GameObject answer;

	// Momentalno prasnje so povekje odgovori
	private QuestionBaseMulti.QuestionMulti currentQuestion;
	// Transform komponentata na dialogot
	private RectTransform rect;
	// Lista na objekti odgovori
	private List<GameObject> answers;
	// Visina
	private float height;

	void Start () {

		// Zemame transform
		rect = GetComponent<RectTransform> ();
		// Zemame visina
		height = rect.sizeDelta.y;
		// Kreirame prazna lista od odgovori
		answers = new List<GameObject>();

	}

	// Pri prikaz generiraj novo prasanje
	public override void SetVisible(bool visible) {
		base.SetVisible(visible);
		if (visible) {
			SetQuestion();
		}
	}


	public void SetQuestion() {

		// Gi briseme site predhodni odgovori
		foreach (GameObject go in answers) {
			Destroy(go);
		}
		answers.Clear();

		// Generirame novo prasanje
		currentQuestion = QuestionBaseMulti.questionBase [Random.Range (0, QuestionBase.questionBase.Length)];
		// Go postavuvame tekstot na prasanjeto
		question.text = currentQuestion.question;
		// Za sekoj odgovor
		for (int i = 0; i < currentQuestion.answers.Length; i++) {
			// Kreirame nov objekt odgovor (od prefabot za izgled na odgovor)
			GameObject tmpAnswer = (GameObject) Instantiate(answer);
			// Go dodavame vo listata na odgovori
			answers.Add(tmpAnswer);
			// Go vgnezduvame  vo dialogot
			tmpAnswer.transform.SetParent(transform, false);
			// Mestime tekst na odgovorot
			Text tmpText = tmpAnswer.GetComponentInChildren<Text>();
			tmpText.text = currentQuestion.answers[i].answer;
			// Mestime koja funkcija da se povika pri klik na odgovorot
			tmpAnswer.GetComponent<Button> ().onClick.AddListener(
				() => ButtonClicked(tmpText));
			// Mestime pozicija vo dijalogot
			RectTransform tmpRect = tmpAnswer.GetComponent<RectTransform> ();
			tmpRect.anchoredPosition = new Vector2(tmpRect.anchoredPosition.x, tmpRect.anchoredPosition.y - (tmpRect.rect.height * i));
		}
		// Go zgolemuvame dijalogot za da gi sobere site odgovori
		rect.sizeDelta = new Vector2(rect.sizeDelta.x, height + (answer.GetComponent<RectTransform>().rect.height * (currentQuestion.answers.Length - 1)));

		
	}

	// Funkcija koja se povikuva pri klik na odgovor.
	public void ButtonClicked(Text value) {

		// Ako e tocen odgovorot povikaj event Answered ako ne generiraj novo prasanje
		string text = value.text;
		for (int i = 0; i < currentQuestion.answers.Length; i++) {
			if (text == currentQuestion.answers[i].answer) {
				if (currentQuestion.answers[i].correct) {
					Answered();
				} else {
					SetQuestion();
				}
				break;
			}
		}

	}

}
