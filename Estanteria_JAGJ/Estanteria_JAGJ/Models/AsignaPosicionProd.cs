using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estanteria_JAGJ.Models
{
    public class AsignaPosicionProd : ViewModels.ViewModelBase
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private int _codEstante;

        public int CodEstante
        {
            get { return _codEstante; }
            set { SetProperty(ref _codEstante, value); }
        }

        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { SetProperty(ref _descripcion, value); }
        }

        private string _nombreProd;

        public string NombreProd
        {
            get { return _nombreProd; }
            set { SetProperty(ref _nombreProd, value); }
        }

        private string _posicion;

        public string Posicion
        {
            get { return _posicion; }
            set { SetProperty(ref _posicion, value); }
        }

        private bool _esLiberado;

        public bool EsLiberado
        {
            get { return _esLiberado; }
            set { SetProperty(ref _esLiberado, value); }
        }

        private DateTime? _fechaLiberado;

        public DateTime? FechaLiberado
        {
            get { return _fechaLiberado; }
            set { SetProperty(ref _fechaLiberado, value); }
        }
    }
}
