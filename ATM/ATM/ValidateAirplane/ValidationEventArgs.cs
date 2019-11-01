using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Converter;

namespace ATM.ValidateAirplane
{
    public class ValidationEventArgs : EventArgs
    {
        public ValidationEventArgs(List<Airplane> planestovalidate)
        {
            this.PlanesToValidate = planestovalidate;
        }
        public List<Airplane> PlanesToValidate { get; set; }
    };
};