﻿using System.ComponentModel.DataAnnotations.Schema;

namespace HomeworkUsingModels.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public bool IsActive { get; set; } = true;
        public string RefreshToken { get; set; } = "";
        public DateTime? RefreshTokenExpireDate { get; set; }
    }
}
