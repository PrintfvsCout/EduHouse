using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnswerDialog : MonoBehaviour {

	public GameObject question;
	
	private QuestionBaseMulti.QuestionMulti currentQuestion;
	private RectTransform rect;
	private float height;

	private Quaternion fixedRotation;
	
	protected Canvas canvas;
	protected Text answer;
	
	
	void Awake () {
		
		fixedRotation = transform.rotation;
		answer = GetComponentInChildren<Text> ();
		canvas = GetComponent<Canvas> ();
		
	}

	void Start () {
		
		rect = GetComponent<RectTransform> ();
		height = rect.sizeDelta.y;

		for (int i = 0; i < QuestionBase.questionBase.Length; i++) {
			GameObject tmpAnswer = (GameObject) Instantiate(question);
			tmpAnswer.transform.SetParent(transform, false);
			Text tmpText = tmpAnswer.GetComponentInChildren<Text>();
			tmpText.text = QuestionBase.questionBase[i].question;
			string ans = QuestionBase.questionBase[i].answer.ToString();
			tmpAnswer.GetComponent<Button> ().onClick.AddListener(
				() => ButtonClicked(ans));
			RectTransform tmpRect = tmpAnswer.GetComponent<RectTransform> ();
			tmpRect.anchoredPosition = new Vector2(tmpRect.anchoredPosition.x, tmpRect.anchoredPosition.y - (tmpRect.rect.height * i));
		}
		height += (question.GetComponent<RectTransform>().rect.height * (QuestionBase.questionBase.Length - 1));
		for (int i = 0; i < QuestionBaseMulti.questionBase.Length; i++) {
			GameObject tmpAnswer = (GameObject) Instantiate(question);
			tmpAnswer.transform.SetParent(transform, false);
			Text tmpText = tmpAnswer.GetComponentInChildren<Text>();
			tmpText.text = QuestionBaseMulti.questionBase[i].question;
			string ans = "";
			for (int j = 0; j < QuestionBaseMulti.questionBase[i].answers.Length; j++) {
				if (QuestionBaseMulti.questionBase[i].answers[j].correct) {
					ans = QuestionBaseMulti.questionBase[i].answers[j].answer;
					break;
				}
			}
			tmpAnswer.GetComponent<Button> ().onClick.AddListener(
				() => ButtonClicked(ans));
			RectTransform tmpRect = tmpAnswer.GetComponent<RectTransform> ();
			tmpRect.anchoredPosition = new Vector2(tmpRect.anchoredPosition.x, tmpRect.anchoredPosition.y - (tmpRect.rect.height * (i + QuestionBase.questionBase.Length)));
		}
		height += (question.GetComponent<RectTransform>().rect.height * (QuestionBaseMulti.questionBase.Length));
		rect.sizeDelta = new Vector2(rect.sizeDelta.x, height);
		
	}
	
	void LateUpdate() {
		
		transform.rotation = fixedRotation;
		
	}
	
	public void SetVisible(bool visible) {
		
		canvas.enabled = visible;
		
	}
	

	public void ButtonClicked(string value) {

		answer.text = value;

	}
}
