using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Domain.Entities
{
    public class FileDocument : Entity
    {
        public string FilePath { get; }

        private FileDocument(string filePath)
        {
            FilePath = Guard.Against.NullOrEmpty(filePath, nameof(filePath));
        }

        public static FileDocument Build(string filePath)
        {
            return new FileDocument(filePath);
        }
    }


}
