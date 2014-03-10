using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bKey.DALC;
namespace bKey.Negocio
{
    public class CommonBC
    {
        private static bKeyEntities _modelobKey;
        public static bKeyEntities ModelobKey
        {
            get
            {
                if (_modelobKey == null)
                    _modelobKey = new bKeyEntities();
                return _modelobKey;
            }
        }
        public CommonBC()
        {

        }
    }
}
