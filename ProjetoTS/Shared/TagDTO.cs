using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTS.Shared
{
    public class TagDTO //UMA TAG POSSUI VÁRIOS PRODUTOS
    {
        public string TagId { get; set; }
        public string Nome { get; set; }
        public List<TagProduto> TagProduto { get; set; }

    }
}