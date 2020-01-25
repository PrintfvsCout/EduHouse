using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{

    // Brzina so koja ke se dvizi covekot. Bidejki e public moze da se menuva od Unity Editor.
    public float speed = 2f;

    // Animator komponenta (State mashina).
    private Animator animator;

    // Funkcija koja se izvrsuva na pocetok.
    void Start()
    {

        // Zemi go animatorot prikacen za covekot.
        animator = GetComponent<Animator>();

    }

    // Funkcija koja se povikuva pri sekoj update na fizikata.
    void FixedUpdate()
    {

        // Vo h se zapisuva -1 ako e stisnata strelkata nalevo ili kopceto a, 1 ako e stisnata strelkata nadesno ili d,
        // 0 vo ostanatite slucai.
        if (Input.GetKey("t") || Input.GetKey("f") || Input.GetKey("g") || Input.GetKey("h"))
        {
            float h = Input.GetAxisRaw("Horizontal1");
            // Vo h se zapisuva -1 ako e stisnata strelkata nadole ili kopceto s, 1 ako e stisnata strelkata nagore ili w,
            // 0 vo ostanatite slucai.

            float v = Input.GetAxisRaw("Vertical1");

            // Vektor koj spored stisnatite kopcinja kazuva vo koja nasoka treba da se dvizi covekot.
            Vector3 direction = new Vector3(h, v).normalized;
            // Pridvizuvanje na covekot vo nasokata direction. Formula za izminat pat S = V * T. V e speed,
            // T e Time.deltaTime sto ima vrednost ednakva na izminatoto vreme od predhodniot do ovoj frame.
            Vector3 positionOffset = direction * speed * Time.deltaTime;
            transform.position += positionOffset;

            // Ako ima dvizenje postavi walking na true.
            animator.SetBool("Walking", positionOffset.magnitude != 0);

            // Rotiranje na covekot vo nasokata koja se dvizi. arctan od nasokata go dava agolot na rotacija na covekot.
            // arctan dava vrednost vo radiani pa mnozime so 180/PI za da dobieme vrednost vo agli.
            transform.eulerAngles = new Vector3(0, 0, -Mathf.Atan2(h, v) * 180 / Mathf.PI);
        }


    }

}
