using System;
using System.ComponentModel.DataAnnotations;

namespace ShrtLy.DAL.Entitites
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
    }
}
