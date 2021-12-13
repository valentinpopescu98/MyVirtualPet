using UnityEngine;

public class ActivateCharacter : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount == 1 && Input.touches[0].phase == TouchPhase.Began)
        {
            TransformCharacter objectScript = GameObject.FindGameObjectWithTag("Character").GetComponent<TransformCharacter>();
            objectScript.isOneActive = !objectScript.isOneActive;

            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            //if (Physics.Raycast(ray, out hit))
            //{
            //    if (hit.transform.tag == "Character")
            //    {
            //        TransformCharacter objectScript = hit.collider.GetComponent<TransformCharacter>();
            //        objectScript.isOneActive = !objectScript.isOneActive;
            //    }
            //}
        }

        if (Input.touchCount == 2 && Input.touches[0].phase == TouchPhase.Began && Input.touches[1].phase == TouchPhase.Began)
        {
            TransformCharacter objectScript = GameObject.FindGameObjectWithTag("Character").GetComponent<TransformCharacter>();
            objectScript.isTwoActive = !objectScript.isTwoActive;

            Ray ray1 = Camera.main.ScreenPointToRay(Input.touches[0].position);
            Ray ray2 = Camera.main.ScreenPointToRay(Input.touches[1].position);
            RaycastHit hit1, hit2;

            //if (Physics.Raycast(ray1, out hit1) && Physics.Raycast(ray2, out hit2))
            //{
            //    TransformCharacter objectScript = GameObject.FindGameObjectWithTag("Character").GetComponent<TransformCharacter>();
            //    objectScript.isTwoActive = !objectScript.isTwoActive;
            //}
        }
    }
}
