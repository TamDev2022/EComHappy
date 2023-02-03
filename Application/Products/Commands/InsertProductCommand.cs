using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Commands
{
    public class InsertProductCommand : IRequest<bool>
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryId { get; set; }
    }

    public class InsertProductCommandHandler : IRequestHandler<InsertProductCommand, bool>
    {
        public Task<bool> Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
