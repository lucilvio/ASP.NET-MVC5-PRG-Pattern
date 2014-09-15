using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;
using MVCSample.Models;

namespace MVCSample
{
    public static class BaseDeClientes
    {
        private static readonly IList<Cliente> Clientes = new List<Cliente>();

        static BaseDeClientes() 
        {
            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                Clientes.Add(new Cliente("Joao", "da Silva", random.Next(120)));
                Clientes.Add(new Cliente("Maria", "das Dores", random.Next(120)));    
            }
        }

        public static IEnumerable<Cliente> Listar()
        {
            return Clientes.ToList();
        }

        public static IEnumerable<Cliente> Listar(Func<Cliente, bool> filtro)
        {
            IEnumerable<Cliente> clientes = Clientes.Where(filtro);

            return clientes;
        }

        public static IEnumerable<Cliente> Listar(int pagina)
        {
            return Clientes.ToList().Skip(10 * pagina).Take(10);
        }

        public static Cliente Buscar(Func<Cliente, bool> criterio)
        {
            return Clientes.Where(criterio).FirstOrDefault();
        }

        public static void Inserir(Cliente cliente)
        {
            if(Clientes.FirstOrDefault(c => c.NomeCompleto.Equals(cliente.NomeCompleto, StringComparison.InvariantCultureIgnoreCase)) != null)
                throw new Exception("Já existe um cliente cadastrado com esse nome");

            Clientes.Add(cliente);
        }

        public static void Alterar(Cliente cliente)
        {
            if (Clientes.Any(c => c.NomeCompleto.Equals(cliente.NomeCompleto, StringComparison.InvariantCultureIgnoreCase) && 
                !c.Id.Equals(cliente.Id)))
                throw new Exception("Já existe um cliente cadastrado com esse nome");

            Cliente clienteAlterado = Clientes.FirstOrDefault(c => c.Id.Equals(cliente.Id));

            clienteAlterado.Nome = cliente.Nome;
            clienteAlterado.Sobrenome = cliente.Sobrenome;
            clienteAlterado.Idade = cliente.Idade;
        }

        public static void Remover(Guid id)
        {
            Cliente cliente = Clientes.FirstOrDefault(c => c.Id.Equals(id));
            Clientes.Remove(cliente);
        }
    }
}