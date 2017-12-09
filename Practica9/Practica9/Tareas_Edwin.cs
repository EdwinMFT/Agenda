using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica9
{
    public class Tareas_Edwin
    {
        string id, titulo, descripcion, matricula, prioridad,fecha_entrega, dependencia, status, desarrollo, tarea, usuarioDep, tareaDep;

        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        [JsonProperty(PropertyName = "titulo")]
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }
        [JsonProperty(PropertyName = "descripcion")]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        [JsonProperty(PropertyName = "matricula")]
        public string Matricula
        {
            get { return matricula; }
            set { matricula = value; }
        }
        [JsonProperty(PropertyName = "prioridad")]
        public string Prioridad
        {
            get { return prioridad; }
            set { prioridad = value; }
        }
        
        [JsonProperty(PropertyName = "fecha_entrega")]
        public string Fecha_entrega
        {
            get { return fecha_entrega; }
            set { fecha_entrega = value; }
        }
        [JsonProperty(PropertyName = "dependencia")]
        public string Dependencia
        {
            get { return dependencia; }
            set { dependencia = value; }
        }
        [JsonProperty(PropertyName = "usuariodependiente")]
        public string UsuarioDepen
        {
            get { return usuarioDep; }
            set { usuarioDep = value; }
        }
        [JsonProperty(PropertyName = "tareadependiente")]
        public string TareaDepen
        {
            get { return tareaDep; }
            set { tareaDep = value; }
        }
        [JsonProperty(PropertyName = "status")]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        [JsonProperty(PropertyName = "desarrollo")]
        public string Desarrollo
        {
            get { return desarrollo; }
            set { desarrollo = value; }
        }
        [JsonProperty(PropertyName = "tarea")]
        public string Tarea
        {
            get { return tarea; }
            set { tarea = value; }
        }
        

    }
}
