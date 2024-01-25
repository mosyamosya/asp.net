using ASp_MVC.Models.Validators;
using System.ComponentModel.DataAnnotations;

namespace ASp_MVC.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "���� '����' � ����'�������.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "������� ����� �� ���� �� 3 �� 50 �������")]
        public string Login { get; set; }

        [Required(ErrorMessage = "���� '������' � ����'�������.")]
        public string? Password { get; set; }


       

        
    }

 

}