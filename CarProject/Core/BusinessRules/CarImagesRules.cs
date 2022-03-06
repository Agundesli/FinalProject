using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BusinessRules
{
    public class CarImagesRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
