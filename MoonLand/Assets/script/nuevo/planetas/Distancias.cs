using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distancias : MonoBehaviour {

	//calcula distancias entre jugador y planetas y devuelve menor via vento al player
	public Transform playerTransform;
	private List<Transform> transformsPlanetas=new List<Transform>();
	public delegate void PlanetaCercano(Transform tansformPlanetaCercano);
	public static event PlanetaCercano PlanetaCercanoDeteccion; 
	private float [] dist;
	private Transform current;
	private Transform planetMenor;

	void Awake () {
	
		GameObject[] obj=GameObject.FindGameObjectsWithTag("planeta_tag");
		if(obj!=null){
		for (int i=0;i<obj.Length;i++ ){
			//lo hago asi porque es mas facil poner una tag que asignar manualmente en el editor, al ser varios transforms 
			transformsPlanetas.Add(obj[i].GetComponent<Transform>());
				//print("transformsPlanetas "+transformsPlanetas[i].name);
			}
		}else{
			//print("objeto nulo problema carga");
		}
		dist=new float[obj.Length];//redimensiono array a la cantidad d planetas
		planetMenor=GetMenorDistance();
		current=planetMenor;//momento inicial son iguales

	}
	void Start(){
		PlanetaCercanoDeteccion(planetMenor);//pasamos el evento al player en gravedad_02

	}
	
	Transform GetMenorDistance(){
		
		int indice=0;
		float distMenor=0;
		Transform AuxMenor=null;
		for(int i=0;i<transformsPlanetas.Count;i++){
		dist[i]=Vector2.Distance(transformsPlanetas[i].position,playerTransform.position);
		//print("distancia "+dist[i]);
			if(i==0){
				//print("distancia menor "+transformsPlanetas[i].name);
				distMenor=dist[i];
				AuxMenor=transformsPlanetas[i];
			}else {
						if(distMenor>dist[i]){
							//print("nueva distancia menor "+transformsPlanetas[i].name);
							distMenor=dist[i];//asigno distancia men
							AuxMenor=transformsPlanetas[i];//guardo transform
						}
				}
		}
	//	print("planeta mas cercano "+AuxMenor.name);
		return AuxMenor;
	}


	void Update () {
	current=GetMenorDistance();
		if(current.name!=planetMenor.name){
			//si hubo un cambio de menor entras
			print("change menor "+current.name);
			PlanetaCercanoDeteccion(current);
			planetMenor=current;//seteo ahroa el planeta menor a current
		}
	}
}
