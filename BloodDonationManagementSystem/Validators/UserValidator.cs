using BloodDonationManagementSystem.Models;
using FluentValidation;

namespace BloodDonationManagementSystem.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator() 
        {
            RuleFor(c => c.TcKimlikNo).NotEmpty().WithMessage("T.C. Kimlik Numarası boş olamaz!");
            RuleFor(c => c.TcKimlikNo).Length(11,11).WithMessage("T.C. Kimlik Numarası 11 haneli olmalıdır!");
            RuleFor(c => c.Isim).NotEmpty().WithMessage("İsim boş olamaz!");
            RuleFor(c => c.Soyisim).NotEmpty().WithMessage("Soyisim boş olamaz!");
            RuleFor(c => c.DogumTarihi).NotEmpty().WithMessage("Lütfen bir tarih seçiniz!");
            RuleFor(c => c.DogumTarihi).LessThan(DateTime.Parse("1/1/2006")).WithMessage("Üye yaşı 18'den büyük olmalıdır!");
            RuleFor(c => c.Sifre).NotEmpty().WithMessage("Şifre boş olamaz!");
            RuleFor(c => c.Sifre).NotEmpty().WithMessage("Şifreniz en az 8 haneden oluşmalı, en az 1 rakam ve büyük harf içermelidir!");
            RuleFor(c => c.Telefon).NotEmpty().WithMessage("Lütfen bir telefon numarası giriniz!");
        }
    }
}
