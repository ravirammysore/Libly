using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libly.Core.APIClients
{
    //A unit-test for book must NOT be using and instance of this
    public class GoodreadsApiClient : IGoodreadsApiClient
    {
        public double GetBookRating(string bookTitle)
        {
            throw new NotImplementedException();
        }
    }
}
