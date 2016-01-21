using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISU
{
    class AndrewModel
    {
        SharedVariables _variables;
        ClientModelWrapper _wrapper;

        public AndrewModel(ClientModelWrapper wrapper, SharedVariables variables)
        {
            _wrapper = wrapper;
            _variables = variables;
        }
    }
}
