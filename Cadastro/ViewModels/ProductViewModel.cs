using Cadastro.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cadastro.ViewModels   
{
    public class ProductViewModel   
    {

        [Key]
        [Display(Name = "Codigo")]
        [Required(ErrorMessage = "O código é requerido.")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome é requerido.")]
        public string Name { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "O valor é requerido.")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Value { get; set; }

        [Display(Name = "Nome Cliente")]
        [ForeignKey("IdClient")]
        public int IdClient { get; set; }

        [Display(Name = "Cliente")]
        public string ClientName { get; set; }

        [Display(Name = "Disponivel")]
        public bool Active { get; set; }

        public IEnumerable<SelectListItem> Clients { get; set; }
    }
}
