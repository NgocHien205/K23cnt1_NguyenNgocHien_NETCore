using System;
using System.ComponentModel.DataAnnotations;


namespace nnhNetCoreMVCLAB5.Models
{
    public class nnhAccount
    {
        [Key]
        [Display(Name = "STT")]
        public int NnhId { get; set; }

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Họ không được để trống")]
        [MinLength(6, ErrorMessage = "Họ tên ít nhất là 6 ký tự")]
        [MaxLength(20, ErrorMessage = "Họ tên tối đa 20 ký tự")]
        public string NnhFullName { get; set; } = string.Empty;

        [Display(Name = "Địa chỉ email")]
        [Required(ErrorMessage = "Địa chỉ email không được để trống")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không đúng định dạng")]

        public string NnhEmail { get; set; } = string.Empty;
        [Display(Name = "Số điện thoại")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
            ErrorMessage = "Số điện thoại không đúng định dạng")]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string NnhPhone { get; set; } = string.Empty;

        [Display(Name = "Địa chỉ thường trú")]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [StringLength(35, ErrorMessage = "Địa chỉ không vượt quá 35 ký tự")]
        public string NnhAddress { get; set; } = string.Empty;

        [Display(Name = "Ảnh đại diện")]
        public string NnhAvatar { get; set; } = string.Empty;

        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        [DataType(DataType.Date)]
        public DateTime NnhBirthday { get; set; }

        [Display(Name = "Giới tính")]
        public string NnhGender { get; set; } = string.Empty;

        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string NnhPassword { get; set; } = string.Empty;

        [Display(Name = "Link Facebook cá nhân")]
        [Required(ErrorMessage = "Link Facebook không được để trống")]
        [Url(ErrorMessage = "Url phải đúng định dạng bao gồm http hoặc https, tên miền VD: https://facebook.com/itvnsoft")]
        public string NnhFacebook { get; set; } = string.Empty;
    }
}
    