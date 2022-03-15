using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LanhesMac.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public List<PedidoDetalhe> PedidoIntens { get; set; }
        [Required(ErrorMessage ="Informe o Nome")]
        [Display(Name ="Nome")]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o Sobrenome")]
        [Display(Name = "Sobrenome")]
        [StringLength(50)]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "Informe o Endereco")]
        [Display(Name = "Nome")]
        [StringLength(100)]
        public string Endereco1{ get; set; }
        [Required(ErrorMessage = "Informe o Complemento do Endereco")]
        [Display(Name = "Complemento")]
        [StringLength(100)]
        public string Endereco2{ get; set; }
        [Required(ErrorMessage = "Informe o Cep")]
        [Display(Name = "Cep")]
        [StringLength(10,MinimumLength = 8)]
        public string Cep { get; set; }
        [StringLength(50)]
        public string Estado{ get; set; }
        [StringLength(50)]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Informe o Telefone")]
        [Display(Name = "Telefone")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string Telefone{ get; set; }

        [Required(ErrorMessage = "Informe o Email")]
        [Display(Name = "Email")]
        [StringLength(80)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+])")]

        public string Email { get; set; }
        public decimal PedidoTotal { get; set; }

        public DateTime PedidoEnviado { get; set; }

    }
}
