using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace Practica9
{
    

    [Table("todoitem")]
    public class TESHDatos
    {
        string matricula;
        String id,nombre,apellidos;

        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }


        [JsonProperty(PropertyName = "matricula")]        
        public string Matricula
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
    }
}
