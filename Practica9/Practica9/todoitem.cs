using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica9
{
    [Table("todoitem")]
    public class todoitem
    {
        long matricula,telefono;
        String id, nombre, apellidos, direccion,carrera,semestre,correo,github;
        bool deleted;

        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }


        [JsonProperty(PropertyName = "matricula"),MaxLength(20),PrimaryKey]
        public long Matricula
        {
            get { return matricula; }
            set { matricula = value; }
        }


        [JsonProperty(PropertyName = "nombre")]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        [JsonProperty(PropertyName = "apellidos")]
        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        [JsonProperty(PropertyName = "direccion")]
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        [JsonProperty(PropertyName = "telefono"),MaxLength(10)]
        public long Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        [JsonProperty(PropertyName = "carrera")]
        public string Carrera
        {
            get { return carrera; }
            set { carrera = value; }
        }

        [JsonProperty(PropertyName = "semestre")]
        public string Semestre
        {
            get { return semestre; }
            set { semestre = value; }
        }

        [JsonProperty(PropertyName = "correo")]
        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        [JsonProperty(PropertyName = "github")]
        public string Github
        {
            get { return github; }
            set { github = value; }
        }

        [JsonProperty(PropertyName = "deleted")]
        public bool Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }
    }
}
