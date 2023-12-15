using UnityEngine;

public class BastaoControle : MonoBehaviour
{
    public Transform pontoFixacao1; // Atribua os objetos vazios para essas variáveis no Inspector
    public Transform pontoFixacao2;
    public GameObject BastaoMesh;

    void Update()
    {
        // Atualize a posição do cilindro com base nos pontos de fixação
        transform.position = pontoFixacao1.position;

        // Atualize a escala do cilindro para esticá-lo entre os pontos de fixação
        if(Vector3.Distance(pontoFixacao1.position, pontoFixacao2.position) > 1)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, Vector3.Distance(pontoFixacao1.position, pontoFixacao2.position));
        }

        // Apontar o cilindro na direção do ponto fixado 2
        transform.LookAt(pontoFixacao2);
    }

    public void MakeVisible()
    {
        BastaoMesh.SetActive(true);
    }

    public void MakeInvisible()
    {
        BastaoMesh.SetActive(false);
    }
}
