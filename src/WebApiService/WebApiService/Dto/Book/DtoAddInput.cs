using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiService.Dto.Book
{
    public class DtoAddInput
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
