
using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            //RuleFor(p => p.Password).MinimumLength(10);
            //RuleFor(p => p.Password).Must(MustBeCharacter).WithMessage("En az bir karakter kullanmak zorundasınız");
            //RuleFor(p => p.Password).Must(MustBeToUpper).WithMessage("En az bir büyük harf olmalı");
            //RuleFor(p => p.Password).Must(MustBeNumeric).WithMessage("En az bir rakam olmalı");
            RuleFor(p => p.Email).Must(MustBe).WithMessage("@ ve . Karakteri zorunludur");
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();
        }
        private bool MustBeNumeric(string arg)
        {
            int[] numeric = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            return numeric.Any(x => arg.Contains(x.ToString()));
        }
        private bool MustBe(string arg)
        {
            return arg.Contains("@.");
        }

        private char[] arr = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O',
         'P', 'R', 'S', 'T', 'U', 'V', 'Y', 'Z', 'X', 'Q'};
        //char[] arrr = new char[] { 'A','B'} ;
        //private char[] arr = { 'A','B'};
        private bool MustBeToUpper(string arg)
        {
            return arr.Any(x => arg.Contains(x));
        }

        private bool MustBeCharacter(string arg)
        {
            var specialChars = ".,?!*+-".ToCharArray();
            return specialChars.Any(x => arg.Contains(x));
        }
    }
}
