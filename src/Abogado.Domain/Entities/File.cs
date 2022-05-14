using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Domain.Entities
{
    public class File : Entity
    {
        public string FilePath { get; }

        private File(string filePath)
        {
            FilePath = Guard.Against.NullOrEmpty(filePath, nameof(filePath));
        }

        public static File Build(string filePath)
        {
            return new File(filePath);
        }
    }


}
