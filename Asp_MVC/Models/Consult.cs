using ASp_MVC.Models.Validators;
using System.ComponentModel.DataAnnotations;

namespace ASp_MVC.Models
{
    public class Consult
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "���� '��'� �������' � ����'�������.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "���� 'Email' � ����'�������.")]
        [EmailAddress(ErrorMessage = "������� ������ Email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "������� �������.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "���� '������ ���� ������������' � ����'�������.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [FutureDate(ErrorMessage = "���� �� ���� � �����������.")]
        [WeekdayDate(ErrorMessage = "������������ �� ���� ��������� � ������.")]
        [WeekMonday(ErrorMessage = "������������ ���� �������� '������' �� ���� ��������� � ��������.")]

        public DateTime Date { get; set; }

        
    }

 

}