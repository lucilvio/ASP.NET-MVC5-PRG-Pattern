using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCSample.Models
{
    public class Cliente
    {
        public Cliente()
        {
            this.Id = Guid.NewGuid();
        }

        public Cliente(string nome, string sobrenome, int idade) : this()
        {
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Idade = idade;
        }

        public Cliente(Cliente cliente) : this()
        {
            this.Nome = cliente.Nome;
            this.Sobrenome = cliente.Sobrenome;
            this.Idade = cliente.Idade;
        }

        public Guid Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O sobrenome é obrigatório.")]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "A idade é obrigatória.")]
        public int Idade { get; set; }
        public string NomeCompleto { get { return this.Nome + " " + this.Sobrenome; } }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Cliente cliente = obj as Cliente;

            return cliente != null && this.Id.Equals(cliente.Id);
        }
    }
}