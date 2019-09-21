using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour {

	public GameObject character;
    Vector3 mouse=new Vector3(0,0,0);
    Rigidbody2D rb;
    SpriteRenderer sp;
    int selection = 0;
    bool move=false;
    ParticleSystem.EmissionModule emission;

    GameObject warpPos;
    bool warpUp = false;

    bool quake = false;


	void Start () {
        rb = character.GetComponent<Rigidbody2D>();
        sp = character.GetComponent<SpriteRenderer>();
        emission = character.GetComponent<ParticleSystem>().emission;
        emission.enabled= false;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Alpha1)) {selection = 0; sp.color = Color.red; }
        if (Input.GetKey(KeyCode.Alpha2)) { selection = 1; sp.color = Color.green; }
        if (Input.GetKey(KeyCode.Alpha3)) {selection = 2; sp.color = Color.blue; }

        if (Input.GetKeyDown(KeyCode.Q)) {
            switch (selection)
            {
                case 0:
                    move = false;
                    rb.velocity = new Vector3(0, 0, 0);
                    setGoal();
                    rb.AddForce((mouse - character.transform.position).normalized * 20, ForceMode2D.Impulse);
                    StartCoroutine(Slash((mouse-character.transform.position).normalized));
                    break;
                case 1:
                    if (!quake)
                    {
                        move = false;
                        rb.velocity = new Vector3(0, 0, 0);
                        StartCoroutine(Earthquake());
                    }
                    else
                    {
                        quake = false;
                        character.transform.localScale /= 3;
                    }
                    break;
                case 2:
                    Instantiate((GameObject)Resources.Load("web"), character.transform.position, Quaternion.identity);
                    break;
            }

        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            switch (selection)
            {
                case 0:
                    if (!warpUp) {
                        
                        warpPos = Instantiate((GameObject)Resources.Load("portal"), character.transform.position,Quaternion.identity);
                        warpUp = true;
                    }
                    else
                    {
                        move = false;
                        rb.velocity = new Vector3(0, 0, 0);
                        character.transform.position = warpPos.transform.position;
                        Destroy(warpPos);
                        warpUp = false;
                    }
                    break;
                case 1:
                    Instantiate((GameObject)Resources.Load("radiation"), character.transform.position, Quaternion.identity);
                    break;
                case 2:
                    StartCoroutine(Buff());
                    break;
            }
        }


        if (Input.GetMouseButton(0))
        {
            move = true;
            setGoal();
        }

        if (Vector2.Distance(character.transform.position, mouse)>1 && move&&!quake)
        {
            rb.velocity = (mouse - character.transform.position).normalized * 3;
        }
        else if(Vector2.Distance(character.transform.position, mouse) <= 1 && move )
        { 
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    void setGoal()
    {
      
        mouse = Input.mousePosition;
        mouse.z = 10;
        mouse = Camera.main.ScreenToWorldPoint(mouse);
    }

    private IEnumerator Slash(Vector3 dir)
    {
        move = false;
       yield return new WaitForSeconds(0.2f);
        GameObject slash = Instantiate((GameObject)Resources.Load("cone"), character.transform.position,  Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        move = true;
        Destroy(slash);
    }
    private IEnumerator Earthquake()
    {
        quake = true;
        character.transform.localScale *=3;
        yield return new WaitForSeconds(5);
        if (quake) { character.transform.localScale /= 3; quake = false; }
    }

    private IEnumerator Buff()
    {
        emission.enabled = true;
        yield return new WaitForSeconds(3);
        emission.enabled = false;
    }
}
