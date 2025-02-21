
using System;
using UnityEngine;

namespace Fornecedores_Model.Features
{
    /// <summary>
    /// Eu tentei gerar em DLL... mas após muita dor de cabeça decidi só replicar o código mesmo
    /// </summary>
    [System.Serializable]
    public class Fornecedor
    {
        [SerializeField]
        public string nome;

        [SerializeField]
        public string email;

        public Fornecedor() {}

        public Fornecedor(string nome, string email)
        {
            this.nome = nome;
            this.email = email;
        }
    }
}
