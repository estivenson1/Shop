﻿namespace Shop.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Product: IEntity
    {
        public int Id { get; set; }

        //Anotaciones 
        [MaxLength(50, ErrorMessage = "El campo {0} solo puede contener {1} caracteres de longitud.")]
        [Required]
        public string Name { get; set; }

        //Decorados
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Display(Name = "Last Purchase")]
        public DateTime LastPurchase { get; set; }

        //Cuando se coloca el signo ? al tipo de dato singnifica que el campo puede recibir null
        [Display(Name = "Last Sale")]
        public DateTime? LastSale { get; set; }

        [Display(Name = "Is Availabe?")]
        public bool IsAvailabe { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public double Stock { get; set; }

        public User User { get; set; }

        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(this.ImageUrl))
                {
                    return null;
                }
                //https://shopeov.azurewebsites.net
                //return $"https://shopzulu.azurewebsites.net{this.ImageUrl.Substring(1)}";
                return $"https://shopeov.azurewebsites.net{this.ImageUrl.Substring(1)}";
            }
        }


    }
}
