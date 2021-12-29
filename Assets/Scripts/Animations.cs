using System.Collections;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public GameObject gameController;
    public Animator charAnim;

    ExperienceSystem xpSystemScript;
    int hits;

    void Start()
    {
        StartCoroutine(ResetHitsScheduler());
    }

    void Update()
    {
        if (hits > 2)
        {
            ResetHits();
        }

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Moved && Input.touches[0].phase == TouchPhase.Moved)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Character")
                {
                    charAnim.SetBool("isLaughing", true);
                }
            }
        }
        else
        {
            charAnim.SetBool("isLaughing", false);
        }

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && Input.touches[0].phase != TouchPhase.Moved)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Character")
                {
                    hits++;
                    charAnim.SetTrigger("isHit");
                    charAnim.SetInteger("hitCounter", hits);
                }
            }
        }
        else
        {
            charAnim.SetBool("isHit", false);
        }
    }

    public void Wave()
    {
        xpSystemScript = gameController.GetComponent<ExperienceSystem>();
        if (xpSystemScript.level > 9)
        {
            charAnim.SetTrigger("isWaving");
        }
    }

    public void Angry()
    {
        xpSystemScript = gameController.GetComponent<ExperienceSystem>();
        if (xpSystemScript.level > 19)
        {
            charAnim.SetTrigger("isAngry");
        }
    }

    void ResetHits()
    {
        hits = 0;
        charAnim.SetInteger("hitCounter", 0);
    }

    IEnumerator ResetHitsScheduler()
    {
        while (true)
        {
            yield return new WaitForSeconds(4f);

            ResetHits();
        }
    }
}
