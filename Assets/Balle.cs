using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balle : MonoBehaviour 
{// Debut du script
	public Rigidbody rb;
	public float vitesseBalle;
	public float vitesseRaquette;
	public Transform RaquetteG;
	public Transform RaquetteD;
	public int ScoreGauche;
	public int ScoreDroit;
	public TextMesh tScoreD;
	public TextMesh tScoreG;

	// Initialisation du jeu
	void Start () 
	{
		NouvellePartie ();
	}

	void NouvellePartie ()
	{
		ScoreDroit = 0;
		ScoreGauche = 0;
		Nouvelleballe ();

	}
	// Boucle du jeu
	void Update () 
	{
		mouvementraquette ();
		Verifierbut ();
	}
	void Verifierbut ()
	{
		if(transform.position.x > 19f)
		{
			ScoreGauche += 1;
			Nouvelleballe ();
		}
		if(transform.position.x < -19f )
		{
			ScoreDroit += 1;
			NouvelleBalleDDroite ();
		}
 
	}
	void mouvementraquette ()
	{
		RaquetteG.Translate (0, Input.GetAxis ("Vertical") * vitesseRaquette * Time.deltaTime , 0);
		RaquetteD.Translate (0, Input.GetAxis ("Horizontal") * vitesseRaquette * Time.deltaTime , 0);
		if(RaquetteG.position.y > 8f)
		{
			RaquetteG.position = new Vector3 (RaquetteG.position.x, 8f, 10f);
		}
		if(RaquetteG.position.y < -8f)
		{
			RaquetteG.position = new Vector3 (RaquetteG.position.x, -8f, 10f);
		}
		if(RaquetteD.position.y > 8f)
		{
			RaquetteD.position = new Vector3 (RaquetteD.position.x, 8f, 10f);
		}
		if(RaquetteD.position.y < -8f)
		{
			RaquetteD.position = new Vector3 (RaquetteD.position.x, -8f, 10f);
		}
	}
	void Nouvelleballe ()
	{
		tScoreG.text = "" + ScoreGauche;
		tScoreD.text = "" + ScoreDroit;
		transform.position = new Vector3 (0f, 0f, 10f);
		rb.velocity = Vector3.zero;
		Invoke ("LancerBalle", 2f);
	}
	void NouvelleBalleDDroite()
	{
		tScoreG.text = "" + ScoreGauche;
		tScoreD.text = "" + ScoreDroit;
		transform.position = new Vector3 (0f, 0f, 10f);
		rb.velocity = Vector3.zero;
		Invoke ("LancerBalledroit", 2f);
	}
	void LancerBalle ()
	{
		rb.AddForce (-1f * vitesseBalle, -1f * vitesseBalle , 0 , ForceMode.VelocityChange);
	}
	void LancerBalledroit()
	{

		rb.AddForce (1f * vitesseBalle, -1f * vitesseBalle , 0 , ForceMode.VelocityChange);
	}
}// Fin du script
	