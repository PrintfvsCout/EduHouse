using UnityEngine;
using System.Collections;

public class QuestionBaseMulti : MonoBehaviour {

	// Struktura na edno prasanje.
	public class QuestionMulti {
		public string question;
		public QuestionMultiAnswer[] answers;
		public QuestionMulti (string question, QuestionMultiAnswer[] answers)
		{
			this.question = question;
			this.answers = answers;
		}
	}

	// Struktura na eden odgovor.
	public class QuestionMultiAnswer {
		public string answer;
		public bool correct;
		public QuestionMultiAnswer (string answer, bool correct)
		{
			this.answer = answer;
			this.correct = correct;
		}
		
	}
	
	// Baza na prasanja. Tuka moze da dodavata novi prasanja.
	public static QuestionMulti[] questionBase = {
		new QuestionMulti("2 + 2", new QuestionMultiAnswer[]{
			new QuestionMultiAnswer("4", true), 
			new QuestionMultiAnswer("5", false),
			new QuestionMultiAnswer("3", false)
		}),
		new QuestionMulti("2 + 1", new QuestionMultiAnswer[]{
			new QuestionMultiAnswer("3", true), 
			new QuestionMultiAnswer("5", false),
			new QuestionMultiAnswer("4", false)
		})
	};
}
