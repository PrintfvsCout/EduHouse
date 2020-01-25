using UnityEngine;
using System.Collections;

public static class QuestionBase
{

	// Struktura na edno prasanje.
	public class Question
    {
		public string question;
		public bool answer;
		public Question (string question, bool answer)
		{
			this.question = question;
			this.answer = answer;
		}
	}

	// Baza na prasanja. Tuka moze da dodavata novi prasanja.
	public static Question[] questionBase = {
		new Question("2 + 2 = 4", true),
		new Question("2 + 2 = 3", false)
	};

}
