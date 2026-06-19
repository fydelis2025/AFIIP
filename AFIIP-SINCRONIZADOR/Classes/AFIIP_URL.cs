using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFIIP_SINCRONIZADOR.Classes
{
    public class AFIIP_URL
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

        private String _UF;
        public String UF
        {
            get
            {
                return this._UF;
            }
            set
            {
                this._UF = value;
            }
        }

        private String _MUNICIPIO;
        public String MUNICIPIO
        {
            get
            {
                return this._MUNICIPIO;
            }
            set
            {
                this._MUNICIPIO = value;
            }
        }

        private int _CODIGOIBGE;
        public int CODIGOIBGE
        {
            get
            {
                return this._CODIGOIBGE;
            }
            set
            {
                this._CODIGOIBGE = value;
            }
        }

        private String _ORGAO;
        public String ORGAO
        {
            get
            {
                return this._ORGAO;
            }
            set
            {
                this._ORGAO = value;
            }
        }

        private String _TITULOBUSCA;
        public String TITULOBUSCA
        {
            get
            {
                return this._TITULOBUSCA;
            }
            set
            {
                this._TITULOBUSCA = value;
            }
        }

        private String _URL;
        public String URL
        {
            get
            {
                return this._URL;
            }
            set
            {
                this._URL = value;
            }
        }

        private String _OBS;
        public String OBS
        {
            get
            {
                return this._OBS;
            }
            set
            {
                this._OBS = value;
            }
        }

        private String _MEMO;
        public String MEMO
        {
            get
            {
                return this._MEMO;
            }
            set
            {
                this._MEMO = value;
            }
        }
    }
}
