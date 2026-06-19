using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFIIP_SINCRONIZADOR.Classes
{
    public class AFIIP_Orgao
    {
        private int _ID;
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                this._ID = value;
            }
        }

        private String _DESCRICAO;
        public String DESCRICAO
        {
            get
            {
                return this._DESCRICAO;
            }
            set
            {
                this._DESCRICAO = value;
            }
        }
    }
}
