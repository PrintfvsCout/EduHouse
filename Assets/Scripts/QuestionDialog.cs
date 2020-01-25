using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// OVAA KLASA NASLEDUVA QuestionDialogBase I PRAVI YES NO DIALOG
public class QuestionDialog : QuestionDialogBase
{

	// Momentalno yes no prasanje
	private QuestionBase.Question currentQuestion;

	// Koga ke se prikaze dialogot generira prasanje
	public override void SetVisible(bool visible)
    {
		base.SetVisible(visible);

		if (visible)
        {
			SetQuestion();
		}
	}

	// Generiraj prasanje
	public void SetQuestion()
    {

		// Postavi momentalno prasanje na random prasanje od bazata
		currentQuestion = QuestionBase.questionBase [Random.Range (0, QuestionBase.questionBase.Length)];
		// Postavi go tekstot vo poleto za prasanje. (question e pole nasledeno od super klasata)
		question.text = currentQuestion.question;

	}

	// Funkcija sto ja povikuvaat Yes No kopcinjata
	public void STAPOVI(bool value)
    {
		// Ako e tocno odgovoreno povijak event Answered ako ne postavi novo prasanje
		if (currentQuestion.answer == value)
        {
			Answered();
		}
        else
        {
			SetQuestion();
		}

	}

}
