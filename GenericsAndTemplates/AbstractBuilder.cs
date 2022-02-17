using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapport.AuxiliaryTools.GenericsAndTemplates
{
    public abstract class AbstractBuilder<T>
    {
        public abstract T GetResult();
    }
}
