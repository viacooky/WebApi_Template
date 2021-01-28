using System;

namespace WebApiService.Dto.Book
{
    public class DtoAddResult : DtoResult
    {
        public new ResultCls Result { get; set; }

        public class ResultCls
        {
            public string Id { get; set; }

            public string Name { get; set; }

            public decimal Price { get; set; }

            public DateTime CreateTime { get; set; }
        }
    }
}