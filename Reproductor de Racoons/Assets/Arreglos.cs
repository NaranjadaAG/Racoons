using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Experimental.GraphView;

public class Arreglos : MonoBehaviour
{
    public GameObject Alertas;
    public GameObject PantallaP;
    public string[] textoAlertas;
    public List<string> usuarios = new List<string>();
    public TMP_InputField NombreUsuario;
    public TMP_InputField NombreNuevoUsuario;
    public TMP_Text AlertasAviso;
    void Start()
    {
        usuarios.Add("Ewaldoelriko");
        usuarios.Add("ReidenOne");
    }
    public void accederUsuario()
    {
        if (usuarios.Contains(NombreUsuario.text))
        {
            PantallaP.SetActive(true);


            Alertas.SetActive(false);
            AlertasAviso.text = textoAlertas[0];
        }
        else
        {
            Alertas.SetActive(true);
            AlertasAviso.text = textoAlertas[1];
        }
    }
    public void crearUsuario()
    {
        if (usuarios.Contains(NombreNuevoUsuario.text))
        {
            Alertas.SetActive(true);
            AlertasAviso.text = textoAlertas[2];
        }
        else
        {
            usuarios.Add(NombreNuevoUsuario.text);
            Alertas.SetActive(true);
            AlertasAviso.text = textoAlertas[3];
        }
    }
}