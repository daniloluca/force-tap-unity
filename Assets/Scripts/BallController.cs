using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	public float speed = 1f;
	public GameObject splash;
	public GameObject collision;
	public Sprite[] paints;
	private Sprite paint;
	private int rand;
	private int colorIndex = 0;
	private GameObject instance;
	private Vector4[] colorList = new Vector4[3];
	public AudioClip splashSound;
	public AudioClip bounceSound;
	public AudioClip endSound;

	void OnCollisionEnter2D(Collision2D collider){
		if(collider.gameObject.tag == "Block"){
			collision.GetComponent<ParticleSystem>().startColor = this.transform.GetComponent<SpriteRenderer>().color;
			Instantiate(collision, this.transform.position, collision.transform.rotation);
			rand = Random.Range(0,paints.Length-1);		

			paint = Sprite.Create(paints[rand].texture, new Rect(paints[rand].rect.x,
																 paints[rand].rect.y, 
																 paints[rand].rect.width, 
																 paints[rand].rect.height),
																 new Vector2(0.5f, 0.75f),
														         100);

			splash.GetComponent<SpriteRenderer>().color = this.transform.GetComponent<SpriteRenderer>().color;
			splash.transform.position = new Vector2(this.transform.position.x, collider.transform.position.y);

			splash.GetComponent<SpriteRenderer>().sprite = paint;
			instance = (GameObject) Instantiate(splash);
			instance.transform.parent = collider.gameObject.transform;
			hit();
		}else if(collider.gameObject.tag == "End"){
			this.transform.GetComponent<AudioSource>().PlayOneShot(endSound, 1);
			Application.LoadLevel ("Menu");
		}else{
			this.transform.GetComponent<AudioSource>().PlayOneShot(bounceSound, 0.4f);
		}
	}

	// Use this for initialization
	void Start () {
		colorList[0] = new Vector4(0, 0, 1, 1);
		colorList[1] = new Vector4(1, 0, 0, 1);
		colorList[2] = new Vector4(0, 1, 0, 1);
		this.transform.GetComponent<SpriteRenderer>().color = colorList[colorIndex];
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform.GetComponent<Rigidbody2D>().isKinematic == false){
			this.transform.Translate(Vector2.up * speed * Time.deltaTime);
		}
	}

	public void hit(){
		this.transform.GetComponent<AudioSource>().PlayOneShot(splashSound, 1);
		this.transform.GetComponent<CircleCollider2D>().enabled = false;
		this.transform.GetComponent<Rigidbody2D>().isKinematic = true;
		this.transform.GetComponent<SpriteRenderer>().enabled = false;
		//particles
		StartCoroutine("deadDelay");
	}

	IEnumerator deadDelay(){
		yield return new WaitForSeconds(0.7f);

		if(colorIndex<colorList.Length-1){
			colorIndex++;
		}else{
			colorIndex = 0;
		}
		this.transform.GetComponent<SpriteRenderer>().color = colorList[colorIndex];

		this.transform.position = new Vector2(0.509f, 0.88f);
		this.transform.GetComponent<SpriteRenderer>().enabled = true;
		this.transform.GetComponent<Rigidbody2D>().isKinematic = false;
		this.transform.GetComponent<CircleCollider2D>().enabled = true;
	}
}
